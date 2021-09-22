using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterModelService : IBaseQueryableEntityService<FilterModel, FilterModelQueryModel>
    {
        List<Type> GetEntityTypes();

        Task<IEnumerable<FilterModelProperty>> GetProperties(Guid id);
        Task<IEnumerable<PropertyInfo>> GetTypePropertyInfos(Guid id);
    }
}
