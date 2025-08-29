using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class TeacherCourse
    {
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
    }
}
