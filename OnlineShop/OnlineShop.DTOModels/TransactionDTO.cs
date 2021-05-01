using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid UserId { get; set; }
        public int OrderId { get; set; }
    }
}
