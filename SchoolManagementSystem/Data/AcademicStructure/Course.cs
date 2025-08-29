using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? CourseCode { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public int? CreditHour { get; set; }
    }
}
