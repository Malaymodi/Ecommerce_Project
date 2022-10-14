using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required]

        //public DateOnly DOB { get; set; }
        public DateTime DOB { get; set; }


        [Required]

        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        public string profilepathurl { get; set; } = "path";
        public IFormFile? ImageUrl { get; set; }
        public UserRole RoleName { get; set; }
        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {

        Active,
        InActive
    }
    public enum UserRole
    {

        Admin,
        Customer
    }
    
}

