using System;

namespace CopeID.Core.Exceptions
{
    public class EntityNotCreatedException : Exception
    {
        public EntityNotCreatedException()
        { }

        public EntityNotCreatedException(string message) : base(message)
        { }

        public EntityNotCreatedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
