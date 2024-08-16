using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models

// set up DbContext for database interaction 
namespace SchoolManagementAPI.Data 
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options) 
        { 
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentProfile>? studentProfiles { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Course>? Courses { get; set; } 
        public DbSet<Enrollment>? Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId }); // Composite key for enrollment 

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentProfile)
                .WithOne(sp => sp.Student)
                .HasForeignKey<StudentProfile>(sp => sp.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TeacherId);
        }
    }
}
