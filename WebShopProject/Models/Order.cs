using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShopProject.Models;

namespace WebShopProject.Models
{
    public class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string OrderAdress { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}