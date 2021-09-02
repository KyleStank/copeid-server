using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterModelService : IBaseEntityService<FilterModel>
    {
        List<Type> GetEntityTypes();

        Task<IEnumerable<FilterModelProperty>> GetProperties(Guid id);
        Task<IEnumerable<PropertyInfo>> GetTypePropertyInfos(Guid id);
    }
}
