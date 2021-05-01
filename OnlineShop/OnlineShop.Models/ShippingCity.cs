using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class ShippingCity
    {
        public int ShippingCityId { get; set; }
        public int CityId { get; set; }
        public int ShippingId { get; set; }

        public virtual City City { get; set; }
        public virtual Shipping Shipping { get; set; }
    }
}
