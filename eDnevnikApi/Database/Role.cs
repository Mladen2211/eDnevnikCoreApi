using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Role
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
