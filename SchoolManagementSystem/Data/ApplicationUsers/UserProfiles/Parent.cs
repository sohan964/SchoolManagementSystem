using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Data.ApplicationUsers.UserProfiles
{
    public class Parent : BaseEntity
    {
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? Address { get; set; }

    }
}
