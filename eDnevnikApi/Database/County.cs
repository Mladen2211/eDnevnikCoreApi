using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class County
    {
        public County()
        {
            Municipalities = new HashSet<Municipality>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}
