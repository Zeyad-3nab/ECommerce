using Ecommerce.Models;
using FinalProject.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IWishList
    {
        public List<WishList> GetWishLists(string id);
        public void AddWishList(WishList wishList);
        public void DeleteWishList(WishList wishlist);
        public WishList GetWishListById(int id);
        public void DeleteAll();
    }
}
