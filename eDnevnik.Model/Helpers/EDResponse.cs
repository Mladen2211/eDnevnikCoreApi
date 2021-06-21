using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Helpers
{
    public class EDResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<ResponseError> ErrorList { get; set; }
        public dynamic Result { get; set; }
    }
}
