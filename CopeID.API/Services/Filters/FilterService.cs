using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterService : BaseQueryableEntityService<Filter, FilterQueryModel>, IFilterService
    {
        DbSet<FilterModel> _filterModelSet;

        public FilterService(CopeIdDbContext context) : base(context)
        {
            _filterModelSet = context.Set<FilterModel>();
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
    }
}
