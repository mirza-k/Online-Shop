using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels
{
    public class OrderProductDTO
    {
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int OrderProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName{ get; set; }
    }
}
