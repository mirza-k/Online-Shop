using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
            ShippingCities = new HashSet<ShippingCity>();
        }

        public int ShippingId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShippingCity> ShippingCities { get; set; }
    }
}
