// Teacher model 
namespace SchoolManagementAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; } = string.Empty;

        // one-to-many relationship
        public ICollection<Student>? Students { get; set; }
    }
}
