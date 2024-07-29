using Ecommerce.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IProduct:IRepository<Product>
    {
        public Product GetProductById(int id);
        public List<Product> GetProductWithBrand();
        public List<Product> GetAllWithOrderByAsc();
        public List<Product> GetAllWithOrderByDesc();
        public List<Product> GetAllProductsWithBrand(int id);
        public List<Product> Search(string temp);
        //void Create(Product product);
        //void SaveChanges();
    }
}
