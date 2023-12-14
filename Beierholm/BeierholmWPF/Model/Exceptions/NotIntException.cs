using System;

namespace BeierholmWPF.Model.Exceptions
{
    public class NotIntException : Exception
    {
        public NotIntException() 
        { 
        }

        public NotIntException(string message) : base(message) 
        { 
        }

        public NotIntException(string message, Exception innerException) : base(message, innerException) 
        { 
        }
    }
}
