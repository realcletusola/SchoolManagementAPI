// course model 
namespace SchoolManagementAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;

        // many-to-many relationship 
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
