using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
