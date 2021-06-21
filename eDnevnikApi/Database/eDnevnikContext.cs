using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eDnevnikApi.Database
{
    public partial class eDnevnikContext : DbContext
    {
        public eDnevnikContext()
        {
        }

        public eDnevnikContext(DbContextOptions<eDnevnikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicDiscipline> AcademicDisciplines { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSchool> UserSchools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Initial Catalog=eDnevnik;Database=eDnevnik;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<AcademicDiscipline>(entity =>
            {
                entity.ToTable("AcademicDiscipline");

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Appointment_Class");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AppointmentCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Appointment_CreatedBy");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Appointment_Subject");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AppointmentUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_Appointment_UpdatedBy");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.ZipCode).HasMaxLength(225);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK_City_Municipality");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.HasOne(d => d.ClassPresidentNavigation)
                    .WithMany(p => p.ClassClassPresidentNavigations)
                    .HasForeignKey(d => d.ClassPresident)
                    .HasConstraintName("FK_Class_ClassPresident");

                entity.HasOne(d => d.ClassTeacherNavigation)
                    .WithMany(p => p.ClassClassTeacherNavigations)
                    .HasForeignKey(d => d.ClassTeacher)
                    .HasConstraintName("FK_Class_ClassTeacher");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_Class_School");
            });

            modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.ToTable("ClassSubject");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_ClassSubject_Class");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ClassSubject_Subject");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("County");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("Municipality");

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Municipalities)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_Municipality_County");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermission");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_RolePermission_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolePermission_Role");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.SchoolYear).HasMaxLength(7);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Schedule_Class");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Schedule_Subject");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("School");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_School_City");

                entity.HasOne(d => d.Principal)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.PrincipalId)
                    .HasConstraintName("FK_School_User");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.TeachingProfessorNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeachingProfessor)
                    .HasConstraintName("FK_Subject_TeachingProfessor");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EMail)
                    .HasMaxLength(225)
                    .HasColumnName("eMail");

                entity.Property(e => e.FirstName).HasMaxLength(225);

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(13)
                    .HasColumnName("JMBG");

                entity.Property(e => e.LastName).HasMaxLength(225);

                entity.Property(e => e.MobileNumber).HasMaxLength(225);

                entity.Property(e => e.Sex).HasMaxLength(2);

                entity.HasOne(d => d.BirthPlace)
                    .WithMany(p => p.UserBirthPlaces)
                    .HasForeignKey(d => d.BirthPlaceId)
                    .HasConstraintName("FK_User_BirthPlace");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_User_Class");

                entity.HasOne(d => d.Residence)
                    .WithMany(p => p.UserResidences)
                    .HasForeignKey(d => d.ResidenceId)
                    .HasConstraintName("FK_User_Residence");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<UserSchool>(entity =>
            {
                entity.ToTable("UserSchool");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.UserSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_UserSchool_School");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSchools)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserSchool_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
