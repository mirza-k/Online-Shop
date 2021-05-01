using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            Transactions = new HashSet<Transaction>();
        }

        public string FirstName { get; set; }
        public DateTime DateBirth { get; set; }
        public string LastName { get; set; }
        public Guid UserAccountId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
