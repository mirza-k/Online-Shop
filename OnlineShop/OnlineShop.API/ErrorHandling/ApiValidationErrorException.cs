using OnlineShop.API.ErrorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.ErrorHandling
{
    public class ApiValidationErrorException : APIResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorException() : base(400)
        {

        }
    }
}
