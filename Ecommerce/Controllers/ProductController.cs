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
            var result=product.GetProducts();
            return View(result);
        }
        public IActionResult GetOne(int id)
        {
           var result= product.GetProductById(id);
            ViewData["GoinWithBrand"] = product.GetProductWithBrand();
            return View(result);
        }
        

    }
}
