using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ShoesSizeProduct
    {
        public int ShoesSizeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantiy { get; set; }
        public int ShoesSizeProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ShoesSize ShoesSize { get; set; }
    }
}
