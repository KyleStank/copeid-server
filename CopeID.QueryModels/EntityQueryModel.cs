using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CopeID.Extensions;
using CopeID.Models;

namespace CopeID.QueryModels
{
    public abstract class EntityQueryModel<TEntity> where TEntity : Entity
    {
        protected static readonly Type _entityType = typeof(TEntity);
        protected static readonly IEnumerable<PropertyInfo> _entityProperties = _entityType.GetProperties().AsEnumerable();

        [FromQuery]
        public Guid[] Id { get; set; } = null;

        [FromQuery]
        public string[] Include { get; set; } = null;

        [FromQuery]
        public string[] OrderBy { get; set; } = null;

        [FromQuery]
        public string[] OrderByDescending { get; set; } = null;

        public virtual IQueryable<TEntity> FilterQuery(IQueryable<TEntity> existingQuery)
        {
            IQueryable<TEntity> query = existingQuery.AsQueryable();
            query = FilterForId(query);
            query = FilterForInclude(query);

            query = GetCustomQuery(query); // Run custom query before ordering.

            query = OrderQuery(query);
            return query;
        }

        public virtual IQueryable<TEntity> FilterForId(IQueryable<TEntity> query)
        {
            if (Id != null)
            {
                query = query.Where(e => Id.Contains(e.Id));
            }

            return query;
        }

        public virtual IQueryable<TEntity> FilterForInclude(IQueryable<TEntity> query)
        {
            if (Include != null)
            {
                string[] includeProperties = FindValidProperties(Include.ToPascalCase());
                foreach (string prop in includeProperties) query = query.Include(prop);
            }

            return query;
        }

        public virtual IQueryable<TEntity> OrderQuery(IQueryable<TEntity> query)
        {
            if (OrderBy != null || OrderByDescending != null)
            {
                // Order query ascendingly.
                string[] ascendingProperties = FindValidProperties(OrderBy?.ToPascalCase());
                for (int i = 0; i < ascendingProperties.Length; i++)
                {
                    string prop = ascendingProperties[i];
                    if (i == 0)
                    {
                        query = query.OrderBy(prop);
                        continue;
                    }

                    query = query.ThenBy(prop);
                }

                // Order query descendingly.
                string[] descendingProperties = FindValidProperties(OrderByDescending?.ToPascalCase());
                for (int i = 0; i < descendingProperties.Length; i++)
                {
                    string prop = descendingProperties[i];
                    if (i == 0 && ascendingProperties.Length == 0)
                    {
                        query = query.OrderByDescending(prop);
                        continue;
                    }

                    query = query.ThenByDescending(prop);
                }
            }

            return query;
        }

        protected abstract IQueryable<TEntity> GetCustomQuery(IQueryable<TEntity> query);

        protected string[] FindValidProperties(string[] properties) =>
            properties?.Where(x => _entityProperties.Any(p => p.Name == x)).ToArray() ?? new string[0];
    }
}
