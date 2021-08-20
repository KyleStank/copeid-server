using System;

using CopeID.Models;

namespace CopeID.Core.Exceptions
{
    public class EntityException<TEntity> : Exception where TEntity : Entity
    {
        protected static readonly Type _entityType = typeof(TEntity);
        protected static readonly string _entityName = _entityType.Name;

        public EntityException() : base()
        { }

        public EntityException(string message) : base(message)
        { }

        public EntityException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
