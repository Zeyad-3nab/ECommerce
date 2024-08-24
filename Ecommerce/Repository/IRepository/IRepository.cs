namespace Ecommerce.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        public void Add(T temp);
        public void Update(T temp);
        public void Delete(T temp);
        public List<T> GetAll();
    }
}