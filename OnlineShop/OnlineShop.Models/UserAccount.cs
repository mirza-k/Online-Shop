using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Users = new HashSet<User>();
        }

        public Guid UserAccountId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
