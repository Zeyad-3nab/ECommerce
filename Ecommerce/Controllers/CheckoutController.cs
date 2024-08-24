using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult success()
        {
            return View();
        }
        public IActionResult cancel()
        {
            return View();
        }
    }
}
