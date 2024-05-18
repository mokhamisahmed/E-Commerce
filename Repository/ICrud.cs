namespace E_Commerce_WebSite.Repository
{
    public interface ICrud<T>
    {

        public Task<T> Create(T entity);

        public Task<List<T>> GetEntities();

        public Task<T> GetById(int id);

        public Task<int> DeleteById(int id);

        public Task<bool> Update(T entity);




    }
}
