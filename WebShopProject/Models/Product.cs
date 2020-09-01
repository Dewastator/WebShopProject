using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShopProject.Models;

namespace WebShopProject.Models
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Is Active")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
        public bool Status { get; set; }
        public ProductSize ProductSize { get; set; }
        public int ProductSizeId { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}