

using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.ApplicationUsers.UserProfiles
{
    public class Student : BaseEntity
    {
        public string? DOB {  get; set; }

        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string? PhotoUrl { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set;}
        public string? Country { get; set; } = null;
        public string? Status { get; set; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Parent? Parent { get; set; }

    }
}
