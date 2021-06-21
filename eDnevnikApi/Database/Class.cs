using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class Class
    {
        public Class()
        {
            Appointments = new HashSet<Appointment>();
            ClassSubjects = new HashSet<ClassSubject>();
            Schedules = new HashSet<Schedule>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public bool? Active { get; set; }
        public int? ClassPresident { get; set; }
        public int? ClassTeacher { get; set; }
        public int? SchoolId { get; set; }
        public bool? Deleted { get; set; }

        public virtual User ClassPresidentNavigation { get; set; }
        public virtual User ClassTeacherNavigation { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
