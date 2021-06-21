using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Type { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Class Class { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
    }
}
