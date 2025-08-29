using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class OptionalGroupCourse
    {

        public int OptionalGroupId { get; set; }
        [ForeignKey("OptionalGroupId")]
        public OptionalGroup? OptionalGroup { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
    }
}
