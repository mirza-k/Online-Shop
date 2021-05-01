using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels
{
    public class ShoppingCartItemDTO
    {
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime AddedInCartDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string ProductName { get; set; }
        public string Username { get; set; }
        //public string ShoeSize { get; set; }
        //public string ClothesSize  { get; set; }
        public int ShoesSizeId { get; set; }
        public int ClothesSizeId { get; set; }
        public string ImageUrl { get; set; }
        public string SubCategory { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
    }
}
