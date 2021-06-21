using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public int? MunicipalityId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }


        public virtual Municipality Municipality { get; set; }
    }
}
