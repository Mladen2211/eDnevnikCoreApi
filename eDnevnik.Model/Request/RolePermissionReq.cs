using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class RolePermissionReq
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
