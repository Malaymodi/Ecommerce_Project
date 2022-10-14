using Ecommerce_Project_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project_WebAPI.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsActive { get; set; } = true;

        public string? Configuration { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsLockedOut => this.LockoutEnabled && (this.LockoutEnd.HasValue && this.LockoutEnd.Value.ToLocalTime() >= DateTime.Now);


        public string CreatedBy { get; set; } = "Malay Modi";
        public string UpdatedBy { get; set; } =  "Malay Modi";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;


        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public static explicit operator ApplicationUser(Task<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }
    }
}
