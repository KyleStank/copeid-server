using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterService : IBaseEntityService<Filter>
    {
        Task<IEnumerable<FilterSection>> GetSections(Guid id);
    }
}
