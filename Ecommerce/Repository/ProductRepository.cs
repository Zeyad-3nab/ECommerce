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

        public void Delete(Product product)
        {
            context.Products.Remove(product);
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
            var result = context.Products.Where(e => e.BrandId == id).Include(e => e.Brand).ToList();
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
                                       //To Join Brand Table    To Search by name of product        or name of brands
            var result = context.Products.Include(e => e.Brand).Where(e => e.Name.Contains(temp)||e.Brand.Name.Contains(temp)).ToList();
            return result;

        }

        public List<Product> GetAllWithOrderByAsc()
        {
            var result = context.Products.OrderBy(e => e.Price).ToList();
            return result;
        }
        public List<Product> GetAllWithOrderByDesc()
        {
            var result = context.Products.OrderByDescending(e => e.Price).ToList();
            return result;
        }
    }
}
