using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.ApplicationUsers;
using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
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
 