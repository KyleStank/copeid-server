using CopeID.Models;

namespace CopeID.Core.Exceptions
{
    public class EntityNotDeletedException<TEntity> : EntityException<TEntity> where TEntity : Entity
    {
        public EntityNotDeletedException() : base($"{_entityName} could not be deleted")
        { }

        public EntityNotDeletedException(string message) : base(message)
        { }

        public EntityNotDeletedException(string message, System.Exception innerException) : base(message, innerException)
        { }
    }
}
