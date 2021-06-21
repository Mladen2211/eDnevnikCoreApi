using System;
using System.Collections.Generic;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class User
    {
        public User()
        {
            AppointmentCreatedByNavigations = new HashSet<Appointment>();
            AppointmentUpdatedByNavigations = new HashSet<Appointment>();
            ClassClassPresidentNavigations = new HashSet<Class>();
            ClassClassTeacherNavigations = new HashSet<Class>();
            Schools = new HashSet<School>();
            Subjects = new HashSet<Subject>();
            UserRoles = new HashSet<UserRole>();
            UserSchools = new HashSet<UserSchool>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Jmbg { get; set; }
        public int? BirthPlaceId { get; set; }
        public string Address { get; set; }
        public int? ResidenceId { get; set; }
        public bool? Deleted { get; set; }
        public int? ClassId { get; set; }
        public bool? Active { get; set; }

        public virtual City BirthPlace { get; set; }
        public virtual Class Class { get; set; }
        public virtual City Residence { get; set; }
        public virtual ICollection<Appointment> AppointmentCreatedByNavigations { get; set; }
        public virtual ICollection<Appointment> AppointmentUpdatedByNavigations { get; set; }
        public virtual ICollection<Class> ClassClassPresidentNavigations { get; set; }
        public virtual ICollection<Class> ClassClassTeacherNavigations { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserSchool> UserSchools { get; set; }
    }
}
