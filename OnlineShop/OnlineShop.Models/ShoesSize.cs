using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ShoesSize
    {
        public ShoesSize()
        {
            ShoesSizeProducts = new HashSet<ShoesSizeProduct>();
        }

        public int ShoesSizeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShoesSizeProduct> ShoesSizeProducts { get; set; }
    }
}
