using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project_WebAPI.APIRequestModels
{
    public class CreateUserRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required]
        
        public DateTime DOB { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        // [NotMapped]

        public string profilepathurl { get; set; }
        public IFormFile ImageUrl { get; set; } = default!;

        public string RoleName { get; set; } = default!;

        public string Status { get; set; } = default!;

    }
}
