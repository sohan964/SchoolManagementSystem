﻿using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class SignIn
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? Password { get; set; }
    }
}
