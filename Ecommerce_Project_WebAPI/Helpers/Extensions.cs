using Ecommerce_Project_WebAPI.Entities;

namespace Ecommerce_Project_WebAPI.Helpers
{
    public static class Extensions
    {
        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
