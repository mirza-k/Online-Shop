using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.ErrorResponses
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public APIResponse(int statusCode, string mess = null)
        {
            this.StatusCode = statusCode;
            this.Message = mess ?? DefaltMessageForStatusCode(statusCode);
        }

        private string DefaltMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request.",
                401 => "You are not authorized",
                404 => "Endpoint Not Found",
                500 => "Error on the server side",
                _ => null
            };
        }
    }
}
