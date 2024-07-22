using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct product;
        private readonly IBrand brand;

        public ProductController(IProduct product,IBrand brand)
        {
            this.product = product;
            this.brand = brand;
        }
        public IActionResult Index()
        {
            var result = product.GetAll();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var result = product.GetProductById(id);
            ViewData["GoinWithBrand"] = product.GetProductWithBrand();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"]=brand.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                Product productt = new Product()
                {
                    Name = productVM.Name,
                    Description = productVM.Description,
                    Photo = productVM.Photo,
                    BrandId = productVM.BrandId,
                    Price = productVM.Price
                };
                product.Add(productt);
                return RedirectToAction("Index", "Product");
            }
            else 
            {
                return View();
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Brands"] = brand.GetAll();
            var result = product.GetProductById(id);
            ProductVM productVM =new ProductVM() 
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Photo = result.Photo,
                BrandId = result.BrandId,
                Price = result.Price
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                Product productt = new Product()
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Description = productVM.Description,
                    Photo = productVM.Photo,
                    BrandId = productVM.BrandId,
                    Price = productVM.Price
                };
                product.Update(productt);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }

        }




        //[HttpGet]
        //public IActionResult Delete(int id) 
        //{
        //    product.Delete(id);
        //    return RedirectToAction("Index","Product");

        //}


    }
}
