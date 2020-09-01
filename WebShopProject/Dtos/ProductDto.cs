using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShopProject.Models;

namespace WebShopProject.Dtos
{
    public class ProductDto
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
        public bool Status { get; set; }

        public int ProductSizeId { get; set; }

        public int ProductTypeId { get; set; }
        
    }
}