using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class UserSchool
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SchoolId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual School School { get; set; }
        public virtual User User { get; set; }
    }
}
