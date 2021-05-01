using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels.AuthenticationResponse
{
    public class AuthenticationResponse
    {
        public List<string> Errors { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
    }
}
