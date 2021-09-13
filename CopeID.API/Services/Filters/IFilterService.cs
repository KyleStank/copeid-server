using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterService : IBaseQueryableEntityService<Filter, FilterQueryModel>
    {
        Task<IEnumerable<FilterSection>> GetSections(Guid id);
    }
}
