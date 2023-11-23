using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeierholmWPF
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
