using FinalProject.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IBrand:IRepository<Brand>
    {
       public Brand GetBrandWithId(int id);
    }
}
