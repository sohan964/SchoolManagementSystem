using SchoolManagementSystem.Data.AcademicStructure;
using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicManagement
{
    public class ClassSchedule : BaseEntity
    {
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section? Section { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }

        public string? AcademicYear { get; set; }
        public string? DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Room { get; set; }
        public string? Remarks { get; set; }
    }
}
