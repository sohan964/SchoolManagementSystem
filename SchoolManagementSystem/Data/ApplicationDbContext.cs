using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.AcademicManagement;
using SchoolManagementSystem.Data.AcademicStructure;
using SchoolManagementSystem.Data.ApplicationUsers;
using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }


        //user Management
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        

        //Academic Structure
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CurriculumCourse> CurriculumCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OptionalGroup> OptionalGroups { get; set; }
        public DbSet<OptionalGroupCourse> OptionalGroupsCourse { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentCourseRegistration> StudentCourseRegistrations { get; set; }
        public DbSet<StudentDepartment> StudentDepartments { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }


        //Academic Management 
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);

            // Composite keys for mapping tables
            //making 2 foreignkey to a primary key of a table
            builder.Entity<OptionalGroupCourse>()
                .HasKey(e => new { e.OptionalGroupId, e.CourseId });

            //making 2 foreignkey to a primary key of a table
            builder.Entity<TeacherCourse>()
                .HasKey(e => new { e.TeacherId, e.CourseId });
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName="ADMIN"},
                new IdentityRole() { Name = "Student", ConcurrencyStamp = "2", NormalizedName = "STUDENT" },
                new IdentityRole() { Name = "Teacher", ConcurrencyStamp = "3", NormalizedName = "TEACHER" }
                );
        }
    }
}
 