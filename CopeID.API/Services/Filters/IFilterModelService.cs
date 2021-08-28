using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterModelService
    {
        Task<List<FilterModel>> GetAll();

        Task<FilterModel> Create(FilterModel model);

        Task<FilterModel> Update(FilterModel model);

        Task Delete(Guid id);
    }
}
