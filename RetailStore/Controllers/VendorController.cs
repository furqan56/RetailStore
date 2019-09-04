using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RetailStore.Data;
using RetailStore.Domain;
using RetailStore.Models;
using RetailStore.Utils;

namespace RetailStore.Controllers
{
    public class VendorController : Controller
    {
        protected ApplicationDbContext context;
        public VendorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                var vendors = context.Vendors.Select(x => new VendorViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactNo = x.ContactNo,
                    TaxId = x.TaxId
                });
                return Json(vendors);
            }
            else
            {
                var vendors = context.Vendors.Select(x => new VendorViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactNo = x.ContactNo,
                    TaxId = x.TaxId
                });
                return View(vendors);
            }
           
        }

        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(VendorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var objectModel = new Vendor()
            {
                Name = model.Name,
                Address = model.Address,
                ContactNo = model.ContactNo,
                TaxId = model.TaxId

            };
            context.Vendors.Add(objectModel);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            

            var vender = context.Vendors.FirstOrDefault(x => x.Id == id);
            var vendors =new VendorViewModel
            {
                Id=vender.Id,
                Name = vender.Name,
                Address = vender.Address,
                ContactNo = vender.ContactNo,
                TaxId = vender.TaxId
            };
            return View(vendors);

        }
        [HttpPost]
        public IActionResult Edit(VendorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var objectModel = new Vendor()
            {
                Id=model.Id,
                Name = model.Name,
                Address = model.Address,
                ContactNo = model.ContactNo,
                TaxId = model.TaxId

            };
            context.Vendors.Update(objectModel);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var vendorToBeDeleted = context.Vendors.FirstOrDefault(v => v.Id == id);

            if (vendorToBeDeleted == null)
                return NotFound();

            return View(vendorToBeDeleted);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDeletion(int id)
        {
            var vendorToBeDeleted = context.Vendors.Find(id);
            context.Vendors.Remove(vendorToBeDeleted);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

  
}