using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model.Request
{
    public class ScheduleReq
    {
        public int Id { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }
        public string SchoolYear { get; set; }
        public bool? IsBreak { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public bool? Deleted { get; set; }

        public bool? Active { get; set; }

    }
}
