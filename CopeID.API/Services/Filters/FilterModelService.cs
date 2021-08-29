using System;
using System.Collections.Generic;
using System.Linq;

using CopeID.Context;
using CopeID.Models;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterModelService : BaseEntityService<FilterModel>, IFilterModelService
    {
        protected readonly static Type _entityType = typeof(Entity);

        public FilterModelService(CopeIdDbContext context) : base(context)
        { }

        public List<Type> GetEntityTypes() =>
            _entityType.Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && t.IsClass && t.IsSubclassOf(_entityType))
                .OrderBy(t => t.FullName)
                .ToList();
    }
}
