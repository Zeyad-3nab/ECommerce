using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class PaymentController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPayment paymentRepository;

        public PaymentController(UserManager<ApplicationUser> userManager,IPayment paymentRepository)
        {
            this.userManager = userManager;
            this.paymentRepository = paymentRepository;
        }
        //Test


        [HttpGet]
        public IActionResult Create(double Total)
        {
            ViewData["Total"] = Total;
            ViewData["UserId"] = userManager.GetUserId(User);
            return View();
        }

        [HttpPost]
        public IActionResult Create(PaymentVM paymentVM)
        {
            if (ModelState.IsValid) 
            {
                Payment payment=new Payment() 
                {
                    Name = paymentVM.Name,
                    Total = paymentVM.Total,
                    City= paymentVM.City,
                    State = paymentVM.State,
                    StreetAddress= paymentVM.StreetAddress,
                    UserId= paymentVM.UserId,
                    Phone= paymentVM.Phone,
                    PostalCode= paymentVM.PostalCode,

                };
                paymentRepository.Add(payment);
                TempData["Payment"] = "Payment Done";
                return RedirectToAction("RemoveAllFromCart", "Cart");


            }
            return View();
        }

    }
}
