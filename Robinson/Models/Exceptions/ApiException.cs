using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robinson.Models.Exceptions
{
    public class ApiException : Exception
    {
        public string UserMessagge { get; set; }

        public ApiException(string messageToUser) : base()
        {
            UserMessagge = messageToUser;
        }

    }
}
