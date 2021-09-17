using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
            .Where(t => t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICustomFilterService)) && !t.IsGenericType && t.IsInterface).AsEnumerable();

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
            
            IQueryable<Filter> query = _set.AsNoTracking()
                .OrderBy(x => x.DisplayName)
                .Include(x => x.FilterModel)
                    .ThenInclude(x => x.FilterModelProperties.OrderBy(p => p.PropertyName))
                .Include(x => x.FilterSections.OrderBy(p => p.DisplayName))
                    .ThenInclude(x => x.FilterSectionParts.OrderBy(p => p.DisplayName))
                        .ThenInclude(x => x.FilterSectionPartOptions.OrderBy(p => p.DisplayName))
                .AsSplitQuery();
            return await query.FirstOrDefaultAsync(x => x.FilterModelId == specimenFilterModel.Id);
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
                    .OrderBy(s => s.DisplayName)
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

            // Find system Type and filter service based on values found above.
            Type modelType = _entityTypes.First(t => t.FullName == filterModel.TypeName);
            Type modelFilterSerivceType = _filterServiceTypes.First(t => t.FullName.Contains(modelType.Name));
            ICustomFilterService modelFilterService = (ICustomFilterService)_serviceProvider.GetService(modelFilterSerivceType);

            Entity objInstance = (Entity)Activator.CreateInstance(modelType);
            objInstance.Id = Guid.Empty;

            var codeResultPropNames = codeResults.Select(r =>
                r.Values.Select(v => new FilterPropertyValueResult
                {
                    Value = v.Value,
                    PropertyName = v.FilterModelProperty.PropertyName
                })
            );

            var props = objInstance.GetType().GetRuntimeProperties();
            foreach (var prop in props)
            {
                FilterPropertyValueResult valueResult = codeResultPropNames.Where(x => x.Any(p => p.PropertyName == prop.Name)).Select(p =>
                {
                    var value = p.FirstOrDefault(x => x.PropertyName == prop.Name);
                    return value;
                }).FirstOrDefault();
                if (valueResult == null) continue;

                MethodInfo setMethod = prop.SetMethod;
                ParameterInfo[] setMethodParams = setMethod.GetParameters();
                if (setMethodParams.Length == 0) continue;

                object[] invokeArgs = null;
                Type parameterType = setMethodParams[0].ParameterType;
                if (parameterType == valueResult.Value.GetType()) invokeArgs = new object[] { valueResult.Value };
                else if (parameterType == typeof(Guid)) invokeArgs = new object[] { Guid.Parse(valueResult.Value) };
                else if (parameterType == typeof(int)) invokeArgs = new object[] { int.Parse(valueResult.Value) };
                else if (parameterType == typeof(double)) invokeArgs = new object[] { double.Parse(valueResult.Value) };
                else if (parameterType == typeof(float)) invokeArgs = new object[] { float.Parse(valueResult.Value) };
                else if (parameterType == typeof(bool)) invokeArgs = new object[] { bool.Parse(valueResult.Value) };

                if (invokeArgs != null) setMethod.Invoke(objInstance, invokeArgs);
            }

            return await modelFilterService.FilterForObject(objInstance);
        }
    }
}
