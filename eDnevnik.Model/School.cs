using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class School
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public bool? Deleted { get; set; }
        public int? PrincipalId { get; set; }
        public bool? Active { get; set; }


        public virtual City City { get; set; }
        public virtual User Principal { get; set; }
    }
}
