using WebShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopProject.ViewModels;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebShopProject.Models
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        ///Show
        [AllowAnonymous]
        public ActionResult Index()
        {
            var product = _context.Products.Include(p => p.ProductSize).ToList();
            product = _context.Products.Include(p => p.ProductType).ToList();

            if (User.IsInRole(RoleName.CanManageProducts))
                return View(product);

            return View("ReadOnlyList", product);
        }

        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult New()
        {
            var productSize = _context.ProductSizes.ToList();
            var productType = _context.ProductTypes.ToList();
            var viewModel = new NewProductViewModel
            {
                ProductSizes = productSize,
                ProductTypes = productType
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Save(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(c => c.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;
                productInDb.Status = product.Status;
                productInDb.ProductSizeId = product.ProductSizeId;
                productInDb.ProductTypeId = product.ProductTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Edit(int Id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == Id);

            if (product == null)
                return HttpNotFound();

            var productSize = _context.ProductSizes.ToList();
            var productType = _context.ProductTypes.ToList();
            var viewModel = new NewProductViewModel
            {
                Product = product,
                ProductSizes = productSize,
                ProductTypes = productType
            };

            return View("ProductForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Delete(int Id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == Id);

            if (product == null)
                return HttpNotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}