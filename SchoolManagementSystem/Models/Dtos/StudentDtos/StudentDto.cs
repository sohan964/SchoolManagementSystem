namespace SchoolManagementSystem.Models.Dtos.StudentDtos
{
    public class StudentDto
    {
        //contact for auth
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

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

        //parent info
        public string? ParentName { get; set; }
        public string? ParentEmail { get; set; }
        //public string ParentPhone { get; set; }

        //department Info
        public string?  DepartmentName { get; set; }
    }
}
