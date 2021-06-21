using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class UserRoleReq
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
