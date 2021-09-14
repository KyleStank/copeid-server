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

            Filter specimenFilter = await _set
                .AsNoTracking()
                .Include(x => x.FilterModel).ThenInclude(x => x.FilterModelProperties)
                .Include(x => x.FilterSections).ThenInclude(x => x.FilterSectionParts).ThenInclude(x => x.FilterSectionPartOptions)
                .FirstOrDefaultAsync(x => x.FilterModelId == specimenFilterModel.Id);

            return specimenFilter;
        }
    }
}
