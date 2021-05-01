using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class City
    {
        public City()
        {
            ShippingCities = new HashSet<ShippingCity>();
            Users = new HashSet<User>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShippingCity> ShippingCities { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
