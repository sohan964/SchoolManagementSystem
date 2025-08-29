using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Data.AcademicStructure;

namespace SchoolManagementSystem.Data.ApplicationUsers.UserProfiles
{
    public class Teacher : BaseEntity
    {
        
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public string? Designation {  get; set; }

        public DateTime? JoinDate { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Status { get; set; }


    }
}
