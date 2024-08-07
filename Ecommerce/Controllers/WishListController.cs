using Ecommerce.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class WishListController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWishList wishListRepository;
        private readonly IProduct product;

        public WishListController(UserManager<ApplicationUser> userManager, IWishList wishListRepository, IProduct product)
        {
            this.userManager = userManager;
            this.wishListRepository = wishListRepository;
            this.product = product;
        }


        public IActionResult Index()
        {
            string? userId = userManager.GetUserId(User);
            if (userId != null)
            {

                var result = wishListRepository.GetWishLists(userId);
                TempData["NumberOfWishLists"] = result.Count();
                return View(result);
            }
            else
            {
                TempData["Login"] = "Please Login";
                return Redirect("https://localhost:7280/Identity/Account/Login");

            }
        }

        public IActionResult AddToWishList(int ProductId)
        {
            string? userId = userManager.GetUserId(User);
            if (userId != null)
            {
                var result = product.GetProductById(ProductId);
                if (result != null)
                {
                    WishList wishList = new WishList()
                    {
                        ProductId = ProductId,
                        UserId = userId
                    };
                    wishListRepository.AddWishList(wishList);
                    TempData["AddToWishList"] = "Added Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["NotFound"] = "Product Not Found";
                    return RedirectToAction("Index");
                } 
               
            }
            else
            {
                TempData["Login"] = "Please Login";
                return Redirect("https://localhost:7280/Identity/Account/Login");
            }
        }

        public IActionResult RemoveFromWishList(int id) 
        {
            var result = wishListRepository.GetWishListById(id);
            if (result != null)
            {
                wishListRepository.DeleteWishList(result);
                TempData["RemoveFromWishList"] = "Product Removed Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["NotFound"] = "Brand Not Found";
                return RedirectToAction("Index");
            }
        }


        public IActionResult RemoveAllFromCart()
        {
            string? userId = userManager.GetUserId(User);
            if (userId != null)
            {
                wishListRepository.DeleteAll();
                TempData["RemoveAllFromWishList"] = "Cart Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Login"] = "Please Login";
                return Redirect("https://localhost:7280/Identity/Account/Login");

            }
          
        }
    }
}
