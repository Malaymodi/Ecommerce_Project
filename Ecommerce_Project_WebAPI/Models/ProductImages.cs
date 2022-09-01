using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductImages
    {
        [Key]
        public int ImageID { get; set; }


        public string ImageUrl { get; set; }

        public string ImageName { get; set; }


        [ForeignKey("PID")]
        public int PID { get; set; }
        public Product productobj { get; set; }
}
}
