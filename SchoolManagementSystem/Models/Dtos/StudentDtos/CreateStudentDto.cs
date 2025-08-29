namespace SchoolManagementSystem.Models.Dtos.StudentDtos
{
    public class CreateStudentDto
    {
        

        //basic info
        //public int StudentId { get; set; }
        public string? DOB { get; set; }

        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string? PhotoUrl { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; } = null;
        public string? Status { get; set; }

        public string? UserId { get; set; }
        //parent info
        public int? ParentId { get; set; }
        
        //department
        public int? DepartmentId { get; set; }
    }
}
