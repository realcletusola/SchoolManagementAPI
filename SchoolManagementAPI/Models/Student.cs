// student models 
namespace SchoolManagementAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; } // primary Key
        public string Name { get; set; } = string.Empty;

        // Foreign Key for Teacher 
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; } // Navigation property

        //one-to-one Relationship 
        public StudentProfile? StudentProfile { get; set; }

        //many-to-many relationship 
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
