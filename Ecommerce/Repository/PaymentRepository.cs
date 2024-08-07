using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository.IRepository;

namespace Ecommerce.Repository
{
    public class PaymentRepository : IPayment
    {
        private readonly ApplicationDbContext context;

        public PaymentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public void Add(Payment payment)
        {
           context.payments.Add(payment);
            context.SaveChanges();
        }
    }
}
