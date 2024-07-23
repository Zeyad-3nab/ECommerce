using FinalProject.Models;

namespace Ecommerce.Repository.IRepository
{
    public interface IBrand:IRepository<Brand>
    {
        Brand GetBrandWithId(int id);
    }
}
