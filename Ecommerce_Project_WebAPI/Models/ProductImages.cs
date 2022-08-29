﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce_Project_WebAPI.Models
{
    public class ProductImages
    {
        [Key]
        public int ImageID { get; set; }

        [ForeignKey("Product")]
        public int PID { get; set; }

        public string ImageUrl { get; set; }

        public string ImageName { get; set; }
    }
}
