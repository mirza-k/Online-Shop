using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DTOModels.ProductQueries
{
    public class ProductQueries
    {
        public string Name { get; set; }
        public int CategoryId{ get; set; }
        public string Brand { get; set; }
        public string Subcategory { get; set; }
        public string Color { get; set; }
        public string GenderCategory { get; set; }
        public bool Search{ get; set; }
    }
}
