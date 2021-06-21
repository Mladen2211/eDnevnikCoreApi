using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Municipality
    {
        public Municipality()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }
        public int? CountyId { get; set; }

        public virtual County County { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
