namespace Ecommerce.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        public List<T> GetAll();
        public void Update(T temp);
        public void Delete(T temp);
        public void Add(T temp);
    }
}
