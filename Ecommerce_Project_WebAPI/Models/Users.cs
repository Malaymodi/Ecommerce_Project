using Ecommerce_Project_WebAPI.IdentityAuth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Project_WebAPI.Models
{
    public class Users
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = default!;

        [Required]
        [NotMapped]
        public DateOnly DOB { get; set; }

        
        public string AspNetUserId { get; set; }
        


        [Required]
        [MaxLength(100)]
        public string Email { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = default!;

        // [NotMapped]
        public string ImageUrl { get; set; } = default!;

        [ForeignKey("UserRole")]
         public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public string Created_By { get; set; } = "Malay Modi";

        public DateTime Created_At { get; set; } = DateTime.Now;

        public string Updated_By { get; set; } = "Malay Modi";

        public DateTime Updated_At { get; set; } = DateTime.Now;



    }
}
