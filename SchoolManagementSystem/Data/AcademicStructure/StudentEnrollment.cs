using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class StudentEnrollment : BaseEntity
    {
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        public int? SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section? Section { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
    }
}
