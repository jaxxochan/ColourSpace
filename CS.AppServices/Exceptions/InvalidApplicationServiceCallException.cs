using System;

namespace CS.Core.AppServices.Exceptions
{
    public class InvalidApplicationServiceCallException : Exception
    {
        public InvalidApplicationServiceCallException(string exception, Exception innerException)
            : base(exception, innerException)
        {

        }
    }
}
