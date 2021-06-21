using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
