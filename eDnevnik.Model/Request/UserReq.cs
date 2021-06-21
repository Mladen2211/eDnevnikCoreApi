using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class UserReq
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
        public bool? Active { get; set; }
        public int? ClassId { get; set; }

    }
}
