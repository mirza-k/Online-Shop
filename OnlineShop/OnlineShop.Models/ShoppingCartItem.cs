using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime AddedInCartDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int ShoppingCartItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        //new columns
        //public int ShoeSize { get; set; }
        //public string ClothesSize { get; set; }
        public int ShoesSizeId { get; set; }
        public int ClothesSizeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
