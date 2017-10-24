using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace Models

{
    
    
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly FutureDBContext _context;

        public ProductsController(FutureDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public Product[] AllProducts()
        {
            System.Console.WriteLine("yes");
            var products = from p in _context.Products
                           let category = _context.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefault()
                           let brand = _context.Brands.Where(b => b.Id == p.BrandId).FirstOrDefault()
                           select new Product(){Id = p.Id, 
                                                Title = p.Title, 
                                                Description = p.Description, 
                                                Short_Description = p.Short_Description, 
                                                Specification = p.Specification, 
                                                Compatibility = p.Compatibility, 
                                                Stock = p.Stock, 
                                                Price = p.Price, 
                                                Amount_Sold = p.Amount_Sold, 
                                                Brand = brand,
                                                BrandId =brand.Id,
                                                Category = category, 
                                                CategoryId = category.Id};
            return products.ToArray();
        }
        [HttpGet("ById/{id}")]
        public IActionResult ById(int id)
        {
            var query = from p in _context.Products
                          where p.Id == id
                          let category = _context.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefault()
                          let brand = _context.Brands.Where(b => b.Id == p.BrandId).FirstOrDefault()
                          select new Product(){Id = p.Id, 
                                               Title = p.Title, 
                                               Description = p.Description, 
                                               Short_Description = p.Short_Description, 
                                               Specification = p.Specification, 
                                               Compatibility = p.Compatibility, 
                                               Stock = p.Stock, 
                                               Price = p.Price, 
                                               Amount_Sold = p.Amount_Sold, 
                                               Brand = brand,
                                               BrandId =brand.Id,
                                               Category = category, 
                                               CategoryId = category.Id};
                          var product  = query.FirstOrDefault();
                          if(product == null)
                          {
                              return NotFound();
                          }
                          return Ok(product);
        }

    }
}
