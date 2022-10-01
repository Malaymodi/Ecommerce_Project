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
        [NotMapped]
        public DateOnly DOB { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        // [NotMapped]
        public string ImageUrl { get; set; } = default!;

    }
}
