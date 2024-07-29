using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class WishListRepository : IWishList
    {

        private readonly ApplicationDbContext context;

        public WishListRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddWishList(WishList wishList)
        {
            context.wishLists.Add(wishList);
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            context.wishLists.ExecuteDelete();
            context.SaveChanges();
        }

        public void DeleteWishList(WishList wishlist)
        {
            context.wishLists.Remove(wishlist);
            context.SaveChanges();
        }

        public WishList GetWishListById(int id)
        {
            var result = context.wishLists.Find(id);
            return result;
        }

        public List<WishList> GetWishLists(string UserId)
        {
            return context.wishLists.Include(e => e.Product).Where(e => e.UserId == UserId).ToList();
        }
    }
}
