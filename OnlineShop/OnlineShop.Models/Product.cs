using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class Product
    {
        public Product()
        {
            ClothesSizeProducts = new HashSet<ClothesSizeProduct>();
            OrderProducts = new HashSet<OrderProduct>();
            ShoesSizeProducts = new HashSet<ShoesSizeProduct>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public DateTime DatePublished { get; set; }
        public int ShippingPrice { get; set; }
        public int BrandId { get; set; }
        public int GenderCategoryId { get; set; }
        public bool IsVisible { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsEditing { get; set; }
        public int ColorId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual GenderCategory GenderCategory { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ClothesSizeProduct> ClothesSizeProducts { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ShoesSizeProduct> ShoesSizeProducts { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
