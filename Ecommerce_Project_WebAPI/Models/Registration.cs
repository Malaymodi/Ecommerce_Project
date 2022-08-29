using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Project_WebAPI.Models
{
    public class Registration
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [NotMapped]
        public DateOnly DOB { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        [ForeignKey("UserRole")]
        public int RoleId { get; set; }

        public string Created_By { get; set; } = "Malay Modi";

        public DateTime Created_At { get; set; }

        public string Updated_By { get; set; } = "Malay Modi";

        public DateTime Updated_At { get; set; }



    }
}
