using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Core.Exceptions;
using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionService : BaseQueryableEntityService<FilterSection, FilterSectionQueryModel>, IFilterSectionService
    {
        public FilterSectionService(CopeIdDbContext context) : base(context)
        { }

        public async Task<IEnumerable<FilterSectionOption>> GetOptions(Guid id)
        {
            FilterSection model = await FindEntityAsync(id, _set.AsNoTracking().Include(x => x.FilterSectionOptions));
            if (model == null) throw new EntityNotFoundException<FilterModel>();

            return model.FilterSectionOptions;
        }
    }
}
