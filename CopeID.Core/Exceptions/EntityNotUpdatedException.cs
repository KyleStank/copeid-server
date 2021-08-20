using System;

namespace CopeID.Core.Exceptions
{
    public class EntityNotUpdatedException : Exception
    {
        public EntityNotUpdatedException()
        { }

        public EntityNotUpdatedException(string message) : base(message)
        { }

        public EntityNotUpdatedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
