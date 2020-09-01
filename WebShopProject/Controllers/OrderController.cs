using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using WebShopProject.Models;
using WebShopProject.ViewModels;
using System.Data.Entity;

namespace WebShopProject.Controllers
{
    
    public class OrderController : Controller
    {
        ApplicationDbContext _context;


        public OrderController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            
            var orders = _context.Orders.ToList();
            
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var products = _context.Products.Where(p => p.Id == id);
            return View(products);
        }
        public ActionResult New()
        {


            var products = _context.Products.Select(p => new
            {
                ProductId = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            var order = new Order();
            foreach (var p in products)
            {
                order.Amount += p.Price;
            }

            if (User.Identity.IsAuthenticated)
            {
                order.CustomerId = User.GetUserId();

            }
            var viewModel = new OrderViewModel
            {
                Order = order,
                Products = new MultiSelectList(products, "ProductId", "Name"),

            };


            return View("OrderForm", viewModel);
        }
        public ActionResult Edit(int id)
        {

            var order = _context.Orders.SingleOrDefault(s => s.Id == id);
            var products = _context.Products.Select(p => new
            {
                ProductId = p.Id,
                Name = p.Name
            }).ToList();
            var defaultSelected = _context.Products.Where(x => x.Orders.Any(y => y.Id == id));

            int[] productId = new int[defaultSelected.Count()];
            int i = 0;
            foreach (var p in defaultSelected)
            {
                productId[i] = p.Id;
                i++;
            }
            var viewModel = new OrderViewModel
            {
                Order = order,
                Products = new MultiSelectList(products, "ProductId", "Name"),
                ProductId = productId
            };
            return View("OrderForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Order order, int[] ProductId)
        {

            if (order.Id == 0)
            {
                _context.Orders.Add(order);
                for (int i = 0; i < ProductId.Length; i++)
                {
                    int id = ProductId[i];
                    var p = _context.Products.SingleOrDefault(x => x.Id == id);
                    _context.Products.Add(p);
                    _context.Products.Attach(p);
                    order.Products.Add(p);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                var orderinDb = _context.Orders.SingleOrDefault(s => s.Id == order.Id);
                orderinDb.OrderAdress = order.OrderAdress;
                orderinDb.OrderDate = order.OrderDate;
                orderinDb.Quantity = order.Quantity;
                orderinDb.CustomerId = User.GetUserId();
                orderinDb.City = order.City;
                orderinDb.Country = order.Country;
                orderinDb.Amount = order.Amount;
                orderinDb.ZipCode = order.ZipCode;

                List<int> productIds = new List<int>();
                foreach (var p in orderinDb.Products)
                {
                    productIds.Add(p.Id);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

        }
        public ActionResult Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(s => s.Id == id);
            List<int> productIds = new List<int>();
            foreach (var p in order.Products)
            {
                productIds.Add(p.Id);
            }
            foreach (var p in productIds)
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == p);
                order.Products.Remove(product);
            }
            _context.SaveChanges();
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult GetProduct(int productId)
        //{

        //    var product = (from s in _context.Products where s.Id == productId select s.Price).ToList();

        //    return Json(product, JsonRequestBehavior.AllowGet);
        //}
    }
}