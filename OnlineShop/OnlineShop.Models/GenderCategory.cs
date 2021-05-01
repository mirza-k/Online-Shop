using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class GenderCategory
    {
        public GenderCategory()
        {
            Products = new HashSet<Product>();
        }

        public int GenderCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
