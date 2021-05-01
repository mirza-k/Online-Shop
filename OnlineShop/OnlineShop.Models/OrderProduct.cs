using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class OrderProduct
    {
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int OrderProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
