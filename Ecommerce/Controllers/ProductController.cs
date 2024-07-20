using Ecommerce.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct product;

        public ProductController(IProduct product)
        {
            this.product = product;
        }
        public IActionResult Index()
        {
            var result=product.GetAll();
            return View(result);
        }
        public IActionResult Details(int id)
        {
           var result= product.GetProductById(id);
            ViewData["GoinWithBrand"] = product.GetProductWithBrand();
            return View(result);
        }
        

    }
}
