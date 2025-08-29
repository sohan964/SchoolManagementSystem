using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class Section : BaseEntity
    {
        public string? Name { get; set; }

        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }
        public string? Status { get; set; }
        public string? AcademicYear { get; set; }
        public string? Remarks { get; set; }


    }
}
