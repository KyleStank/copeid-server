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
            FilterModel specimenFilterModel = await _filterModelSet
                .AsNoTracking()
                .Include(x => x.FilterModelProperties)
                .FirstOrDefaultAsync(x => x.TypeName == specimenTypeName);
            
            IQueryable<Filter> query = _set.AsNoTracking()
                .OrderBy(x => x.DisplayName)
                .Include(x => x.FilterModel)
                    .ThenInclude(x => x.FilterModelProperties.OrderBy(p => p.PropertyName))
                .Include(x => x.FilterSections.OrderBy(p => p.DisplayName))
                    .ThenInclude(x => x.FilterSectionParts.OrderBy(p => p.DisplayName))
                        .ThenInclude(x => x.FilterSectionPartOptions.OrderBy(p => p.DisplayName));
            return await query.FirstOrDefaultAsync(x => x.FilterModelId == specimenFilterModel.Id);
        }

        public async Task<string> FilterResults(FilterResultRequestViewModel resultRequest)
        {
            Filter filter = await _set
                .AsNoTracking()
                .Include(f => f.FilterModel).ThenInclude(x => x.FilterModelProperties)
                .FirstOrDefaultAsync(f => f.Id == resultRequest.FilterId);

            FilterModel filterModel = filter.FilterModel;
            ICollection<FilterModelProperty> filterModelProperties = filterModel.FilterModelProperties;

            Type modelType = _entityTypes.First(t => t.FullName == filterModel.TypeName);
            Type modelFilterSerivceType = _filterServiceTypes.First(t => t.FullName.Contains(modelType.Name));
            ICustomFilterService modelFilterService = (ICustomFilterService) _serviceProvider.GetService(modelFilterSerivceType);

            List<PropertyInfo> props = new List<PropertyInfo>();

            FilterResultViewModel[] results = resultRequest.Results;
            foreach (FilterResultViewModel result in results)
            {
                FilterSection filterSection = await _filterSectionSet
                    .AsNoTracking()
                    .Include(s => s.FilterSectionParts).ThenInclude(p => p.FilterSectionPartOptions)
                    .FirstOrDefaultAsync(s => s.Id == result.SectionId);

                FilterOptionValueViewModel[] optionValues = result.OptionValues;
                IEnumerable<FilterSectionPart> filterSectionParts = filterSection.FilterSectionParts
                    .Where(p => optionValues.Any(v => p.Id == v.PartId))
                    .Select(p =>
                    {
                        p.FilterSectionPartOptions = p.FilterSectionPartOptions
                            .Where(o => optionValues.Any(v => o.Id == v.PartOptionId))
                            .ToList();
                        return p;
                    })
                    .ToList();

                // TODO: Fix after FilterSectionPart has a property ID instead of FilterSection
                //FilterModelProperty filterModelProperty = filterModelProperties.First(p => p.Id == filterSection.FilterModelPropertyId);
                //PropertyInfo modelPropertyInfo = modelType.GetProperty(filterModelProperty.PropertyName);

                //var opts = filterSectionParts.Select(p => new
                //{
                //    Options = p.FilterSectionPartOptions.Select(o => new
                //    {
                //        Code = o.Code,
                //        Value = o.Value
                //    })
                //});

                //props.Add(modelPropertyInfo);
            }

            return "";
        }
    }
}
