using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class Class
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool? Active { get; set; }
        public int? ClassPresident { get; set; }
        public int? ClassTeacher { get; set; }
        public int? SchoolId { get; set; }
        public bool? Deleted { get; set; }


        public virtual User ClassPresidentNavigation { get; set; }
        public virtual User ClassTeacherNavigation { get; set; }
        public virtual School School { get; set; }
    }
}
