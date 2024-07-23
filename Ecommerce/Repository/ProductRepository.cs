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

        public void Add(Product temp)
        {
            context.Products.Add(temp);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Products.Find(id);
            context.Products.Remove(result);
            context.SaveChanges();
        }


        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public List<Product> GetAllProductsWithBrand(int id)
        {
            var result = context.Products.Where(e => e.BrandId == id)
                .Include(e => e.Brand).ToList();
            return result;
        }
        public List<Product> GetProductWithBrand()
        {
            var result = context.Products.Include(e => e.Brand).ToList();
            return result;
        }

        public void Update(Product temp)
        {
            context.Products.Update(temp);
            context.SaveChanges();
        }
        public List<Product> Search(string temp)
        {
            var result = context.Products.Where(e => e.Name.Contains(temp)).Include(e => e.Brand).ToList();
            return result;

        }
    }
}
