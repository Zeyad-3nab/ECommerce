using Ecommerce.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IProduct:IRepository<Product>
    {
        Product GetProductById(int id);
        List<Product> GetProductWithBrand();
        //void Create(Product product);
        //void SaveChanges();
    }
}
