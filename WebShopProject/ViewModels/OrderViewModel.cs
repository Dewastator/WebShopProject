using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopProject.Models;

namespace WebShopProject.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public MultiSelectList Products { get; set; }
        public int[] ProductId { get; set; }
    }
}