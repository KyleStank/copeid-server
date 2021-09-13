using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterSectionService : IBaseEntityService<FilterSection>
    {
        Task<IEnumerable<FilterSectionOption>> GetOptions(Guid id);
    }
}
