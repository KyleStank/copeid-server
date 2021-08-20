using CopeID.Models;

namespace CopeID.Core.Exceptions
{
    public class EntityNotFoundException<TEntity> : EntityException<TEntity> where TEntity : Entity
    {
        public EntityNotFoundException() : base($"{_entityName} could not be found")
        { }

        public EntityNotFoundException(string message) : base(message)
        { }

        public EntityNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        { }
    }
}
