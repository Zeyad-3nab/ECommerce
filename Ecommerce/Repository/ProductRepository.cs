using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Product GetProductById(int id)
        {
           return context.Products.Find(id); 
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
       public List<Product> GetProductWithBrand()
        {
            var result=context.Products.Include(e=>e.Brand).ToList();
            return result;
        }
       
    }
}
