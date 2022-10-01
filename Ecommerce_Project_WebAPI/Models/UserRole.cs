using System.ComponentModel.DataAnnotations;


namespace Ecommerce_Project_WebAPI.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        public string? RoleName { get; set; }

        public bool IsActive { get; set; } = false;

        public Users? Users { get; set; }


    }
}
