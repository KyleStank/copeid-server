using System;
using System.Collections.Generic;

using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterModelService : IBaseEntityService<FilterModel>
    {
        List<Type> GetEntityTypes();
    }
}
