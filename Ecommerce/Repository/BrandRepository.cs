using Ecommerce.Data;
using Ecommerce.Repository.IRepository;
using FinalProject.Models;

namespace Ecommerce.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly ApplicationDbContext context;

        public BrandRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Brand temp)
        {
            context.Brands.Add(temp);
            context.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return context.Brands.ToList();
        }

        public Brand GetBrandWithId(int id)
        {
            var result = context.Brands.Find(id);
            return result;
        }


        public void Update(Brand temp)
        {
            context.Brands.Update(temp);
            context.SaveChanges();
        }
    }
}
