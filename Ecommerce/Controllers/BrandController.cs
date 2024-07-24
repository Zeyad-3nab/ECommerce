using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using FinalProject.Models;
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
                return RedirectToAction("GetAll", "Brand");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = brand.GetBrandWithId(id);
            return View(result);
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
                return RedirectToAction("GetAll");
            }
            return View();
        }




        public IActionResult Delete(int id)
        {
            brand.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
