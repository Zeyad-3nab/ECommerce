using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using Newtonsoft.Json;
using Stripe.Checkout;

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
                double TotalOfPrice=0;
                double Total=0;
                var result=cartRepository.GetCarts(userId);
                //TempData["cartItemsss"] = JsonConvert.SerializeObject(result);


                TempData["cartItems"] = JsonConvert.SerializeObject(result, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

                Total = result.Sum(e => e.Quantity * e.Product.Price);
                TotalOfPrice = result.Sum(e => e.Product.Price);

                //TempData["NumberOfCarts"]=result.Count();
                ViewData["Total"] = Total;
                ViewData["TotalOfPrice"] = TotalOfPrice;
                return View(result);
            }
            else
            {
                return RedirectToPage("/Account/Register", new { area = "Identity" });


            }
        }



        [HttpGet]
        public IActionResult AddToCart(int ProductId) 
        {
            var result = product.GetProductById(ProductId);
            if (result != null) 
            {
                ViewData["product"] = result;
                ViewData["GoinWithBrand"] = product.GetProductWithBrand();
                ViewData["UserId"] = userManager.GetUserId(User);
                return View();
            }
            TempData["NotFound"] = "Not Found";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddToCart(CartVM cartVM)
        {
            if (ModelState.IsValid)
            {
               
                    Cart cart = new Cart()
                    {
                        ProductId = cartVM.ProductId,
                        Quantity = cartVM.Quantity,
                        UserId = cartVM.UserId
                    };
                    cartRepository.AddCart(cart);
                TempData["AddToCart"] = "Added Successfully";
                return RedirectToAction("Index");
             
            }
            else
            {
                TempData["Login"] = "Please Login";
                return RedirectToPage("/Account/Register", new { area = "Identity" });   //Change to redirect to login page
            }
        }



        public IActionResult RemoveFromCart(int id)
        {
            var result = cartRepository.GetCartById(id);
            if (result != null)
            {
                cartRepository.DeleteCart(result);
                TempData["RemoveFromCart"] = "Product Removed Successfully";
                return RedirectToAction("Index");
            }
            else 
            {
                   TempData["NotFound"] = "Product Not Found";
                return RedirectToAction("Index");
            }
        }



        public IActionResult RemoveAllFromCart() 
        {
            cartRepository.DeleteAll();
            TempData["RemoveAllFromCart"] = "Cart Deleted Successfully";
            return RedirectToAction("Index");
        }




        public IActionResult Pay() 
        {
            var options=new SessionCreateOptions
            {
                PaymentMethodTypes=new List<string> {"card"},
                LineItems=new List<SessionLineItemOptions>(),
                Mode="payment",
                SuccessUrl=$"{Request.Scheme}://{Request.Host}/checkout/success",
                CancelUrl=$"{Request.Scheme}://{Request.Host}/checkout/cancel",
            };

            var result = JsonConvert.DeserializeObject<IEnumerable<Cart>>((string)TempData["cartItems"]);
            foreach (var item in result) 
            {
                var line = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name,
                            Description = item.Product.Description,
                        },
                        UnitAmount =(long)item.Product.Price*100,

                    },
                    Quantity = item.Quantity,
                };
                options.LineItems.Add(line);

            }


            var service=new SessionService();
            var session = service.Create(options);
            return Redirect(session.Url);

        }

    }
}
