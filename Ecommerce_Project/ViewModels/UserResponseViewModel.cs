using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class UserResponseViewModel
    {

        public long UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required]
    
        //public DateOnly DOB { get; set; }
        public DateTime DOB { get; set; }


        public string AspNetUserId { get; set; }

        [Display(Name = "Profile Pic")]
        public string imageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        public string Role { get; set; }

        public string Status { get; set; } = default!;

        public Status Enumstatus { get; set; }

        public string? searchString { get; set; }

    }
}
