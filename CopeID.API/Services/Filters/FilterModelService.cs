using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Core.Exceptions;
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

        public async Task<IEnumerable<FilterModelProperty>> GetProperties(Guid id)
        {
            FilterModel model = await FindEntityAsync(id, _set.AsNoTracking().Include(x => x.FilterModelProperties));
            if (model == null) throw new EntityNotFoundException<FilterModel>();

            return model.FilterModelProperties;
        }

        public async Task<IEnumerable<PropertyInfo>> GetTypePropertyInfos(Guid id)
        {
            FilterModel model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<FilterModel>();

            string typeName = model.TypeName;
            if (typeName == null) throw new EntityException<FilterModel>("Type name is null");

            List<Type> entityTypes = GetEntityTypes();
            Type type = entityTypes.FirstOrDefault(t => t.FullName == typeName);
            if (type == null) throw new EntityNotFoundException<FilterModel>($"Type [${typeName}] does not exist");

            return type.GetProperties();
        }
    }
}
