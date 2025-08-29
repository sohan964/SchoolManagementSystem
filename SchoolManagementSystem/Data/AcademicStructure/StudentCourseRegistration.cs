using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class StudentCourseRegistration : BaseEntity
    {
        public int EnrollmentId { get; set; }
        [ForeignKey("EnrollmentId")]
        public StudentEnrollment? StudentEnrollment { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
        public string? AcademicYear { get; set; }
        public int OptionalGroupId { get; set; }
        [ForeignKey("OptionalGroupId")]
        public OptionalGroup? OptionalGroup { get; set; }
        public bool? IsCompulsory { get; set; }
        public string? Remarks { get; set; }
    }
}