using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopProject.Models;

namespace WebShopProject.ViewModels
{
    public class NewProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductSize> ProductSizes { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        

    }
}