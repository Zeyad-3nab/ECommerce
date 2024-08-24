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
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IProduct product, IBrand brand ,IWebHostEnvironment webHostEnvironment)
        {
            this.product = product;
            this.brand = brand;
            this.webHostEnvironment = webHostEnvironment;
        }

        //All Product
        public IActionResult Index()
        {
            var result = product.GetAll();
            return View(result);
        }


        //One Product
        public IActionResult Details(int id)
        {
            var result = product.GetProductById(id);
            if (result != null)
            {

                //Send Brand With it
                ViewData["GoinWithBrand"] = product.GetProductWithBrand();
                return View(result);
            }
            else 
            {

                //If it is not found
                TempData["NotFound"] = "Brand Not Found";
                return RedirectToAction("Index");
            }
           
        }



        public IActionResult GetAllProductsWithBrand(int id)
        {
            var result = product.GetAllProductsWithBrand(id);
            if (result != null)
            {
                return View(result);
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"] = brand.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productVM,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    string imagesFolderBath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    Directory.CreateDirectory(imagesFolderBath);
                    if (!string.IsNullOrEmpty(productVM.Photo))
                    {
                        string oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, productVM.Photo.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(imagesFolderBath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    productVM.Photo = fileName;
                }




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
                return RedirectToAction("Create", "Product");
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
        public async Task<IActionResult> Edit(ProductVM productVM,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    string imagesFolderBath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    Directory.CreateDirectory(imagesFolderBath);
                    if (!string.IsNullOrEmpty(productVM.Photo))
                    {
                        string oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, productVM.Photo.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(imagesFolderBath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    productVM.Photo = fileName;
                }




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
                return RedirectToAction("Create", "Product");
            }


        }



        public IActionResult Delete(int id)
        {
            var result=product.GetProductById(id);
            if (result != null)
            {
                product.Delete(result);
                TempData["DeleteProduct"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["NotFound"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
           
        }

        public IActionResult Search(string temp)
        {

            var result = product.Search(temp);
            if (result != null)
            {
                return View("Index", result);
            }
            else 
            {
                TempData["NotFound"] = "Not Found";
                return RedirectToAction("Index");
            }
        }
        public IActionResult OrderByAsc()
        { 
            var result = product.GetAllWithOrderByAsc();
            return View("Index",result);
        }
        public IActionResult OrderByDesc()
        {
            var result = product.GetAllWithOrderByDesc();
            return View("Index", result);
        }




    }
}
