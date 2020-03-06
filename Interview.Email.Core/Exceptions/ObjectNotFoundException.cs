using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Core.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {
        }
    }
}
