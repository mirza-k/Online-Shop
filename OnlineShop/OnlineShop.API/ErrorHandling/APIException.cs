using OnlineShop.API.ErrorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.ErrorHandling
{
    public class APIException : APIResponse
    {
        public string Details { get; set; }

        public APIException(int statusCode, string mess = null, string details = null) : base(statusCode, mess)
        {
            this.Details = details;
        }
    }
}
