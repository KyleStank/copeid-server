using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Core.Exceptions;
using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterService : BaseEntityService<Filter>, IFilterService
    {
        public FilterService(CopeIdDbContext context) : base(context)
        { }

        public async Task<IEnumerable<FilterSection>> GetSections(Guid id)
        {
            Filter model = await FindEntityAsync(id, _set.AsNoTracking().Include(x => x.FilterSections));
            if (model == null) throw new EntityNotFoundException<FilterModel>();

            return model.FilterSections;
        }
    }
}
