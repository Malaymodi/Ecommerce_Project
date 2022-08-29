using System.ComponentModel.DataAnnotations;


namespace Ecommerce_Project_WebAPI.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public string? RoleName { get; set; }

        public bool IsActive { get; set; } = false;

       
    }
}
