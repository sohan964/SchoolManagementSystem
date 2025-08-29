using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.AcademicStructure
{
    public class OptionalGroup :BaseEntity
    {
        public string? Name { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        public string? AcademicYear { get; set; }
        public int? MinRequired {  get; set; }

        public int? MaxAllowed { get; set; }
        public string? Remarks { get; set; }

    }
}
