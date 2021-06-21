using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class ClassSubjectReq
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public bool? Deleted { get; set; }

        public bool? Active { get; set; }

    }
}
