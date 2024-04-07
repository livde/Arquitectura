using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.application.Exceptions
{
    public class PublisherException
    {
    }
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

}
