using SchoolManagementSystem.Data.AcademicStructure;
using SchoolManagementSystem.Data.ApplicationUsers;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.Dtos.TeacherDtos
{
    public class CreateTeacherDto
    {
        public string? UserId { get; set; }
        

        public int? DepartmentId { get; set; }

        public string? Designation { get; set; }

        public DateTime? JoinDate { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Status { get; set; }
    }
}
