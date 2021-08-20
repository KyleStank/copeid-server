using CopeID.Models;

namespace CopeID.Core.Exceptions
{
    public class EntityNotCreatedException<TEntity> : EntityException<TEntity> where TEntity : Entity
    {
        public EntityNotCreatedException() : base($"{_entityName} could not be created")
        { }

        public EntityNotCreatedException(string message) : base(message)
        { }

        public EntityNotCreatedException(string message, System.Exception innerException) : base(message, innerException)
        { }
    }
}
