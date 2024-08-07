using Ecommerce.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IPayment
    {
        public void Add(Payment payment);
    }
}
