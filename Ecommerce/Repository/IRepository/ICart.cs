using FinalProject.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface ICart
    {
        public List<Cart> GetCarts(string id);
        public void AddCart(Cart cart);
        public void DeleteCart(Cart cart);
        public Cart GetCartById(int id);
        public void DeleteAll();
    }
}
