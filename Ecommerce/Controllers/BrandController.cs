using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
   
    public class BrandController : Controller
    {
        private readonly IBrand brand;

        public BrandController(IBrand brand)
        {
            this.brand = brand;
        }


        public IActionResult Index()
        {
            var result = brand.GetAll();
            return View(result);
        }


        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandVM brandVM)
        {
            if (ModelState.IsValid)
            {
                var Brand = new Brand()
                {
                    Name = brandVM.Name,
                    Description = brandVM.Description,
                };
                brand.Add(Brand);
                TempData["CreateBrand"] = "Brand created Successfully";
                return RedirectToAction("Index", "Brand");
            }
            return View();
        }


      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = brand.GetBrandWithId(id);
            if (result != null)
            {
                return View(result);
            }
            else 
            {
                TempData["NotFound"] = "Brand Not Found";
                return RedirectToAction("Index", "Brand");
            }
        }
        [HttpPost]
        public IActionResult Edit(BrandVM brandVM)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand()
                {
                    Id = brandVM.Id,
                    Name = brandVM.Name,
                    Description = brandVM.Description,
                };
                this.brand.Update(brand);
                TempData["UpdateBrand"] = "Brand Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



       
        public IActionResult Delete(int id)
        {
            var result = brand.GetBrandWithId(id);
            if (result != null)
            {
                brand.Delete(result);
                TempData["DeleteBrand"] = "Brand Deleted Successfully";
                return RedirectToAction("Index","Brand");
            }
            else 
            {
                TempData["NotFound"] = "Brand Not Found";
                return RedirectToAction("Index", "Brand");
            }
           
        }
    }
}
