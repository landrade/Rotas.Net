using System;
using System.Runtime.Serialization;

namespace Routes.Domain.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException(String message, Exception ex)
            : base(message, ex)
        {
            
        }
    }
}
