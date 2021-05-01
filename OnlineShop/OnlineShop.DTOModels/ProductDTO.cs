using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public DateTime DatePublished { get; set; }
        public int BrandId { get; set; }
        public int GenderCategoryId { get; set; }
        public bool IsVisible { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsEditing { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string GenderName { get; set; }
        public string SubCategoryName { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
    }
}
