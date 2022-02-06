using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            Invalid_ride_type,
            Invalid_distance,
            Invalid_time,
            Null_rides,
            Invalid_user_id
        }

        ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }

}
