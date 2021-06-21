using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Jmbg { get; set; }
        public int? BirthPlaceId { get; set; }
        public string Address { get; set; }
        public int? ResidenceId { get; set; }
        public bool? Deleted { get; set; }
        public int? ClassId { get; set; }
        public bool? Active { get; set; }
        public School School { get; set; }

        public virtual City BirthPlace { get; set; }
        public virtual Class Class { get; set; }
        public virtual City Residence { get; set; }

        public List<Role> Roles { get; set; }
    }
}
