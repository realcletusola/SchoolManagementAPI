// student profile model 
namespace SchoolManagementAPI.Models
{
    public class StudentProfile
    {
        public int StudentProfileId { get; set; } // primary Key 
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Foreign Key for student (one-to-one Relationship)
        public int StudentId { get; set; }
        public Student? Student { get; set; } // Navigation Property 
    }
}
