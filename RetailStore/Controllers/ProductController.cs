using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RetailStore.Data;
using RetailStore.Domain;
using RetailStore.Models;

namespace RetailStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.AsNoTracking().Select(x => new ProductViewModel
            {
                CategoryName = x.Category.Name,
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                SalePrice = x.SalePrice
            }).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                SalePrice = model.SalePrice,
                Description = model.Description
            };
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}