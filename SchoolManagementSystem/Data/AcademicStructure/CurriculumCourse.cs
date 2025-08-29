using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class CurriculumCourse : BaseEntity
    {
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set;}

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public string? AcademicYear { get; set; }
        public bool IsCompulsory { get; set; }
        public string? Remarks { get; set; }

    }
}
