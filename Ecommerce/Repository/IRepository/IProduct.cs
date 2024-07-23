using Ecommerce.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IProduct:IRepository<Product>
    {
        Product GetProductById(int id);
        List<Product> GetProductWithBrand();
        List<Product> GetAllProductsWithBrand(int id);
        List<Product> Search(string temp);
        //void Create(Product product);
        //void SaveChanges();
    }
}
