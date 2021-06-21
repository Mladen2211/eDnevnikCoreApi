using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class CityReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public int? MunicipalityId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }


    }
}
