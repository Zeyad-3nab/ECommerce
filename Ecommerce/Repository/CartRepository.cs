using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CartRepository : ICart
    {
        private readonly ApplicationDbContext context;

        public CartRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public List<Cart> GetCarts(string Userid)
        {
            return context.Carts.Include(e=>e.Product).Where(e=>e.UserId==Userid).ToList();
        }
        public Cart GetCartById(int id) 
        {
            var cart = context.Carts.Find(id);
            return cart;
        }

       
        public void DeleteAll()
        {
            context.Carts.ExecuteDelete();
            context.SaveChanges();
        }
    }
}
