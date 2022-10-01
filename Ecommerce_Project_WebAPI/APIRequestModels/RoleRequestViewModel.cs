using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project_WebAPI.APIRequestModels
{
    public class RoleRequestViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role name is required"), StringLength(200, MinimumLength = 2, ErrorMessage = "Role name must be between 2 and 200 characters")]
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }


    }
}
