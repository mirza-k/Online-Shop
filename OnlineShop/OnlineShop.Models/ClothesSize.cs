using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ClothesSize
    {
        public ClothesSize()
        {
            ClothesSizeProducts = new HashSet<ClothesSizeProduct>();
        }

        public int ClothesSizeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClothesSizeProduct> ClothesSizeProducts { get; set; }
    }
}
