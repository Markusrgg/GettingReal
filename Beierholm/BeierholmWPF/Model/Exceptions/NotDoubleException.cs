using System;

namespace BeierholmWPF.Model.Exceptions
{
    public class NotDoubleException : Exception
    {
        public NotDoubleException() 
        { 
        }

        public NotDoubleException(string message) : base(message) 
        { 
        }

        public NotDoubleException(string message, Exception innerException) : base(message, innerException) 
        { 
        }
    }
}
