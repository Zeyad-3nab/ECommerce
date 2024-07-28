using Ecommerce.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        //Type string       in controller inject to user Manager to get user id 


        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICart cartRepository;
        private readonly IProduct product;

        public CartController( UserManager<ApplicationUser> userManager,ICart cartRepository,IProduct product)
        {
            this.userManager = userManager;
            this.cartRepository = cartRepository;
            this.product = product;
        }

        public IActionResult Index()
        {
            string? userId = userManager.GetUserId(User);
            if (userId != null) 
            {
                var result=cartRepository.GetCarts(userId);
                return View(result);
            }
            else
            {
                
            return RedirectToAction("Index" , "Product");  //Change to redirect to login page
            }
        }



        [HttpGet]
        public IActionResult AddToCart(int ProductId) 
        {
            var result = product.GetProductById(ProductId);
            ViewData["product"] = result;
            ViewData["GoinWithBrand"] = product.GetProductWithBrand();
            ViewData["UserId"] =userManager.GetUserId(User);
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(CartVM cartVM)
        {
            if (ModelState.IsValid)
            {
                if (cartVM.Quantity <= 0 || cartVM.Quantity > 50)
                {
                    return RedirectToAction("AddToCart","Cart",cartVM.ProductId);
                }
                else 
                {
                    Cart cart = new Cart()
                    {
                        ProductId = cartVM.ProductId,
                        Quantity = cartVM.Quantity,
                        UserId = cartVM.UserId
                    };
                    cartRepository.AddCart(cart);
                    return RedirectToAction("Index");
                }
             
            }
            else
            {
                return View(cartVM);  //Change to redirect to login page
            }
        }

        public IActionResult RemoveFromCart(int id)
        {
            var result = cartRepository.GetCartById(id);
            if (result != null)
            {
                cartRepository.DeleteCart(result);
                return RedirectToAction("Index");
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult RemoveAllFromCart() 
        {
            cartRepository.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}
