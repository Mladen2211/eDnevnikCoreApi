using AutoMapper;
using eDnevnik.Model;
using eDnevnik.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnikApi.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.AcademicDiscipline, eDnevnik.Model.AcademicDiscipline>();
            CreateMap<eDnevnik.Model.AcademicDiscipline, Database.AcademicDiscipline>();
            CreateMap<AcademicDisciplineReq, Database.AcademicDiscipline>();

            CreateMap<Database.Appointment, eDnevnik.Model.Appointment>();
            CreateMap<eDnevnik.Model.Appointment, Database.Appointment>();
            CreateMap<AppointmentReq, Database.Appointment>();

            CreateMap<Database.City, eDnevnik.Model.City>();
            CreateMap<eDnevnik.Model.City, Database.City>();
            CreateMap<CityReq, Database.City>();

            CreateMap<Database.Class, eDnevnik.Model.Class>();
            CreateMap<eDnevnik.Model.Class, Database.Class>();
            CreateMap<ClassReq, Database.Class>();

            CreateMap<Database.ClassSubject, eDnevnik.Model.ClassSubject>();
            CreateMap<eDnevnik.Model.ClassSubject, Database.ClassSubject>();
            CreateMap<ClassSubjectReq, Database.ClassSubject>();

            CreateMap<Database.County, eDnevnik.Model.County>();
            CreateMap<eDnevnik.Model.County, Database.County>();
            CreateMap<CountyReq, Database.County>();

            CreateMap<Database.Municipality, eDnevnik.Model.Municipality>();
            CreateMap<eDnevnik.Model.Municipality, Database.Municipality>();
            CreateMap<MunicipalityReq, Database.Municipality>();

            CreateMap<Database.Permission, eDnevnik.Model.Permission>();
            CreateMap<eDnevnik.Model.Permission, Database.Permission>();
            CreateMap<PermissionReq, Database.Permission>();

            CreateMap<Database.Role, Role>();
            CreateMap<Role, Database.Role>();
            CreateMap<RoleReq, Database.Role>();

            CreateMap<Database.RolePermission, eDnevnik.Model.RolePermission>();
            CreateMap<eDnevnik.Model.RolePermission, Database.RolePermission>();
            CreateMap<RolePermissionReq, Database.RolePermission>();

            CreateMap<Database.Schedule, eDnevnik.Model.Schedule>();
            CreateMap<eDnevnik.Model.Schedule, Database.Schedule>();
            CreateMap<ScheduleReq, Database.Schedule>();

            CreateMap<Database.School, eDnevnik.Model.School>();
            CreateMap<eDnevnik.Model.School, Database.School>();
            CreateMap<SchoolReq, Database.School>();


            CreateMap<Database.Subject, eDnevnik.Model.Subject>();
            CreateMap<eDnevnik.Model.Subject, Database.Subject>();
            CreateMap<SubjectReq, Database.Subject>();

            CreateMap<Database.User, eDnevnik.Model.User>();
            CreateMap<eDnevnik.Model.User, Database.User>();
            CreateMap<UserReq, Database.User>();

            CreateMap<Database.UserRole, eDnevnik.Model.UserRole>();
            CreateMap<eDnevnik.Model.UserRole, Database.UserRole>();
            CreateMap<UserRoleReq, Database.UserRole>();

            CreateMap<Database.UserSchool, eDnevnik.Model.UserSchool>();
            CreateMap<eDnevnik.Model.UserSchool, Database.UserSchool>();
            CreateMap<UserSchoolReq, Database.UserSchool>();
        }
    }
}
