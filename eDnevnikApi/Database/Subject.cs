using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Subject
    {
        public Subject()
        {
            Appointments = new HashSet<Appointment>();
            ClassSubjects = new HashSet<ClassSubject>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeachingProfessor { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual User TeachingProfessorNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
