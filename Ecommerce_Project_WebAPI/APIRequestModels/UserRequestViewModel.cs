using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project_WebAPI.APIRequestModels
{
    public class UserRequestViewModel
    {
        public class UserLoginModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            public bool RememberMe { get; set; }

        }
    }
}
