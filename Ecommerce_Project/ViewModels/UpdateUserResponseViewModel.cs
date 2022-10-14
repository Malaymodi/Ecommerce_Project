using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Project.ViewModels
{
    public class UpdateUserResponseViewModel
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

        public string imageUrl { get; set; }

       
        public IFormFile? ImageUrl { get; set; }
      //  public string profilepathurl { get; set; } 
        public UserRole RoleName { get; set; }
        public Statusupdate Enumstatus { get; set; }

    }
    public enum Statusupdate
    {

        Active,
        InActive
    }
}
