using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class School
    {
        public School()
        {
            Classes = new HashSet<Class>();
            UserSchools = new HashSet<UserSchool>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public bool? Deleted { get; set; }
        public int? PrincipalId { get; set; }
        public bool? Active { get; set; }

        public virtual City City { get; set; }
        public virtual User Principal { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<UserSchool> UserSchools { get; set; }
    }
}
