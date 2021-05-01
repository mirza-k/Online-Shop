using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
