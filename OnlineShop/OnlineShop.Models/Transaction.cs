using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid UserId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
