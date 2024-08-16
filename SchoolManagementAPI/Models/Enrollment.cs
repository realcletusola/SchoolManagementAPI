// enrollment model 
namespace SchoolManagementAPI.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; } // Foreign key to student model 
        public Student? Student { get; set; } // Navigation property 

        public int CourseId { get; set; } // Foriegn Key to course 
        public Course? Course { get; set; } // Navigation Property 
    }
}
