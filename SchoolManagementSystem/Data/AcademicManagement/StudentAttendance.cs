using SchoolManagementSystem.Data.AcademicStructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicManagement
{
    public class StudentAttendance : BaseEntity
    {
        public int StudentCourseRegistrationId { get; set; }
        [ForeignKey("StudentCourseRegistrationId")]
        public StudentCourseRegistration? StudentCourseRegistration { get; set; }
        public string? Date {  get; set; }
        public string? Status { get; set; }
        
    }
}
