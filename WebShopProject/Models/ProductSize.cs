using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopProject.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Size { get; set; }

    }
}