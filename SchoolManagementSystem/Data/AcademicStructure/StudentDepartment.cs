using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class StudentDepartment : BaseEntity
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set;}
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set ; }
        public string? Remarks { get; set; }
    }
}
