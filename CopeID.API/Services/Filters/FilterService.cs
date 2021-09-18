using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.API.FilterModels;
using CopeID.API.ViewModels;
using CopeID.Context;
using CopeID.Models;
using CopeID.Models.Filters;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionCodeResult
    {
        public string SectionCode { get; set; }

        public IEnumerable<FilterValueCodeResult> Values { get; set; }

        public FilterSectionCodeResult(string section, IEnumerable<FilterValueCodeResult> values)
        {
            SectionCode = section;
            Values = values;
        }
    }

    public class FilterValueCodeResult
    {
        public string Code { get; set; }

        public string Value { get; set; }

        public FilterModelProperty FilterModelProperty { get; set; }
    }

    public class FilterPropertyValueResult
    {
        public string Value { get; set; }

        public string PropertyName { get; set; }
    }

    // TODO: Holy spagetti, refactor this already.
    public class FilterService : BaseQueryableEntityService<Filter, FilterQueryModel>, IFilterService
    {
        private readonly IEnumerable<Type> _entityTypes = Assembly.GetAssembly(typeof(Entity)).ExportedTypes
            .AsEnumerable();
        private readonly IEnumerable<Type> _filterServiceTypes = Assembly.GetAssembly(typeof(ICustomFilterService)).ExportedTypes
            .Where(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICustomFilterService)) && !t.IsGenericType && t.IsInterface)
            .AsEnumerable();
        private readonly IEnumerable<Type> _filterModelTypes = Assembly.GetAssembly(typeof(IFilterModel)).ExportedTypes
            .Where(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IFilterModel)) && t.IsClass && !t.IsAbstract)
            .AsEnumerable();

        private readonly IServiceProvider _serviceProvider;

        private readonly DbSet<FilterModel> _filterModelSet;
        private readonly DbSet<FilterSection> _filterSectionSet;
        private readonly DbSet<FilterSectionPart> _filterSectionPartSet;
        private readonly DbSet<FilterSectionPartOption> _filterSectionPartOptionSet;

        public FilterService(CopeIdDbContext context, IServiceProvider serviceProvider) : base(context)
        {
            _serviceProvider = serviceProvider;

            _filterModelSet = context.Set<FilterModel>();
            _filterSectionSet = context.Set<FilterSection>();
            _filterSectionPartSet = context.Set<FilterSectionPart>();
            _filterSectionPartOptionSet = context.Set<FilterSectionPartOption>();
        }

        public async Task<Filter> GetSpecimenFilter()
        {
            string specimenTypeName = typeof(Specimen).FullName;
            FilterModel specimenFilterModel = await _filterModelSet.AsNoTracking()
                .Include(x => x.FilterModelProperties)
                .FirstOrDefaultAsync(x => x.TypeName == specimenTypeName);

            Filter specimenFilter = await _set.AsNoTracking()
                .OrderBy(x => x.DisplayName)
                .Include(x => x.FilterModel)
                    .ThenInclude(x => x.FilterModelProperties)
                .Include(x => x.FilterSections)
                    .ThenInclude(x => x.FilterSectionParts)
                        .ThenInclude(x => x.FilterSectionPartOptions)
                .AsSplitQuery()
                .FirstOrDefaultAsync(f => f.FilterModelId == specimenFilterModel.Id);

            specimenFilter.FilterModel.FilterModelProperties = specimenFilter.FilterModel.FilterModelProperties.OrderBy(p => p.PropertyName).ToArray();
            specimenFilter.FilterSections = specimenFilter.FilterSections.OrderBy(s => s.Order).Select(s =>
            {
                s.FilterSectionParts = s.FilterSectionParts.OrderBy(p => p.Order).Select(p =>
                {
                    p.FilterSectionPartOptions = p.FilterSectionPartOptions.OrderBy(o => o.Order).ToArray();
                    return p;
                }).ToArray();
                return s;
            }).ToArray();

            return specimenFilter;
        }

        public async Task<object> FilterResults(FilterResultRequestViewModel resultRequest)
        {
            // Find filter, filter model, and filter model properties.
            Filter filter = await _set.AsNoTracking()
                .Include(f => f.FilterModel).ThenInclude(x => x.FilterModelProperties)
                .OrderBy(f => f.DisplayName)
                .AsSplitQuery()
                .FirstOrDefaultAsync(f => f.Id == resultRequest.FilterId);
            FilterModel filterModel = filter.FilterModel;
            ICollection<FilterModelProperty> filterModelProperties = filterModel.FilterModelProperties;

            // Loop through results and convert each item to a better suited, more usable data format.
            List<FilterSectionCodeResult> codeResults = new List<FilterSectionCodeResult>();
            FilterResultViewModel[] results = resultRequest.Results;
            foreach (FilterResultViewModel result in results)
            {
                FilterSection filterSection = await _filterSectionSet
                    .AsNoTracking()
                    .Include(s => s.FilterSectionParts).ThenInclude(p => p.FilterSectionPartOptions)
                    .OrderBy(s => s.Order)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(s => s.Id == result.SectionId);

                FilterOptionValueViewModel[] optionValues = result.OptionValues;
                var parts = filterSection.FilterSectionParts
                    .Where(p => optionValues.Any(v => p.Id == v.PartId))
                    .Select(p =>
                    {
                        FilterSectionPartOption option = p.FilterSectionPartOptions.First(o => optionValues.Any(v => o.Id == v.PartOptionId));
                        return new FilterValueCodeResult
                        {
                            Code = option.Code,
                            Value = option.Value,
                            FilterModelProperty = filterModelProperties.First(x => x.Id == p.FilterModelPropertyId)
                        };
                    })
                    .AsEnumerable();

                codeResults.Add(new FilterSectionCodeResult(filterSection.Code, parts));
            }

            // Find system Type and custom filter model types based on values found above.
            Type modelType = _entityTypes.First(t => t.FullName == filterModel.TypeName);
            Type filterModelType = _filterModelTypes.First(t => t.BaseType == modelType);

            // Create instance of the type specified from the filter model.
            Entity objInstance = (Entity)Activator.CreateInstance(filterModelType);
            IEnumerable<IEnumerable<FilterPropertyValueResult>> codeResultPropNames = codeResults.Select(r =>
                r.Values.Select(v => new FilterPropertyValueResult
                {
                    Value = v.Value,
                    PropertyName = v.FilterModelProperty.PropertyName
                })
            );

            // Find all properties of object instance and set value of each based on selected options.
            IEnumerable<PropertyInfo> modelDeclaredTypes = modelType.GetProperties();
            IEnumerable<PropertyInfo> filterDeclaredTypes = objInstance.GetType().GetProperties().Where(p => p.DeclaringType == filterModelType);
            IEnumerable<PropertyInfo> props = modelDeclaredTypes.Select(p =>
            {
                PropertyInfo filterProp = filterDeclaredTypes.FirstOrDefault(x => x.Name == p.Name);
                if (filterProp != null) return filterProp;
                return p;
            });
            foreach (var prop in props)
            {
                // Convert results from above to only its string value.
                string resultValue = codeResultPropNames.Where(x => x.Any(p => p.PropertyName == prop.Name)).Select(p =>
                {
                    var value = p.FirstOrDefault(x => x.PropertyName == prop.Name);
                    return value.Value;
                }).FirstOrDefault();
                if (resultValue == null) continue;

                // Find the set method and its parameters of the current property.
                MethodInfo setMethod = prop.SetMethod;
                ParameterInfo[] setMethodParams = setMethod.GetParameters();
                if (setMethodParams.Length == 0) continue;

                Type parameterType = setMethodParams[0].ParameterType;
                Type nullableParameterType = Nullable.GetUnderlyingType(parameterType);
                Type comparisionType = nullableParameterType ?? parameterType;

                // Dynamically convert the string property value to the correct type value and invoke the set method.
                TypeConverter converter = TypeDescriptor.GetConverter(comparisionType);
                object[] invokeArgs = new object[] { converter.ConvertFrom(resultValue) };
                if (invokeArgs != null) setMethod.Invoke(objInstance, invokeArgs);
            }

            // Find correct filter service and invoke filter method to return result of filtered items.
            Type modelFilterSerivceType = _filterServiceTypes.First(t => t.FullName.Contains(modelType.Name));
            ICustomFilterService modelFilterService = (ICustomFilterService)_serviceProvider.GetService(modelFilterSerivceType);
            return await modelFilterService.FilterForObject(objInstance);
        }
    }
}
