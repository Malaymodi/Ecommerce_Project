using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project_WebAPI.APIRequestModels
{
    public class UpdateUserRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        //[Required]
        //[MaxLength(100)]
        public string LastName { get; set; } = default!;

         [Required]
         [NotMapped]
          public DateTime DOB { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

       // public string profilepathurl { get; set; }

        public string imageUrl { get; set; }
        public IFormFile ImageUrl { get; set; } = default!;

      
        public string RoleName { get; set; } = default!;

        public string Enumstatus { get; set; } 
    }
}
