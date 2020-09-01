using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopProject.Models;

namespace WebShopProject.Controllers.Api
{
    [AllowAnonymous]
    public class ProductsController : ApiController
    {
        ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IHttpActionResult GetProduct(int Id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == Id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + product.Id), product);
        }

        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Status = product.Status;
            productInDb.ProductSizeId = product.ProductSizeId;
            productInDb.ProductTypeId = product.ProductTypeId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == Id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Products.Remove(productInDb);
            _context.SaveChanges();


        }
    }
}
