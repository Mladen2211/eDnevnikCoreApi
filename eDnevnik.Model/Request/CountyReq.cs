using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class CountyReq
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? Deleted { get; set; }

        public bool? Active { get; set; }

    }
}
