using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ClothesSizeProduct
    {
        public int ClothesSizeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int ClothesSizeProductId { get; set; }

        public virtual ClothesSize ClothesSize { get; set; }
        public virtual Product Product { get; set; }
    }
}
