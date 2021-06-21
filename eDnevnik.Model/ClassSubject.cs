using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class ClassSubject
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
