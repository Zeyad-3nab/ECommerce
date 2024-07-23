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

        public ProductController(IProduct product, IBrand brand)
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

        public IActionResult GetAllProductsWithBrand(int id)
        {
            var result = product.GetAllProductsWithBrand(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"] = brand.GetAll();
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
                TempData["CreateProduct"] = "Product created Successfully";
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
            if (result != null)
            {
                ProductVM productVM = new ProductVM()
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
            else 
            {
                TempData["NotFound"] = "Not Found";

                return RedirectToAction("index", "Product");
            }
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
                TempData["UpdateProduct"] = "Product updated Successfully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }

        }


        public IActionResult Search(string temp)
        {
            var result = product.Search(temp);
            return View("Index", result);
        }



    }
}
