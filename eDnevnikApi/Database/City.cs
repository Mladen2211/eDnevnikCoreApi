using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class City
    {
        public City()
        {
            Schools = new HashSet<School>();
            UserBirthPlaces = new HashSet<User>();
            UserResidences = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }
        public int? MunicipalityId { get; set; }

        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<User> UserBirthPlaces { get; set; }
        public virtual ICollection<User> UserResidences { get; set; }
    }
}
