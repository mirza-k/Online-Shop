using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineShop.Models
{
    public partial class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public int RolePermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
