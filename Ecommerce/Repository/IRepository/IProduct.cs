using Ecommerce.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IProduct
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        List<Product> GetProductWithBrand();
        //void Create(Product product);
        //void SaveChanges();
    }
}
