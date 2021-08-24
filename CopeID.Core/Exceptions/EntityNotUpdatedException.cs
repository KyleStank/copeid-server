using CopeID.Models;

namespace CopeID.Core.Exceptions
{
    public class EntityNotUpdatedException<TEntity> : EntityException<TEntity> where TEntity : Entity
    {
        public EntityNotUpdatedException() : base($"{_entityName} could not be updated")
        { }

        public EntityNotUpdatedException(string message) : base(message)
        { }

        public EntityNotUpdatedException(string message, System.Exception innerException) : base(message, innerException)
        { }
    }
}
