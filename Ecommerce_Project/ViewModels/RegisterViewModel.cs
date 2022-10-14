using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required]
        [NotMapped]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        public IFormFile ImageUrl { get; set; }

       public Status Enumstatus { get; set; }

       // public string enumdata { get; set; }
    }

    public enum Status
    {
       Active,
       InActive
    }
}
