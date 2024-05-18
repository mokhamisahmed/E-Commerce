using E_Commerce_WebSite.Database;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebSite.Repository
{
    public class Service<T> : ICrud<T> where T : class
    {

        private readonly Connection context;

        public Service(Connection context)
        {
            this.context = context;

        }

        public async Task<T> Create(T entity)
        {

            var addedEntity = this.context.Set<T>().Add(entity).Entity;
            await this.context.SaveChangesAsync();
            return addedEntity;


        }

        public async Task<int> DeleteById(int id)
        {
            var entity = await this.context.Set<T>().FindAsync(id);

            this.context.Remove(entity);
               return await this.context.SaveChangesAsync();
            
           


        }

        public async Task<T> GetById(int id)
        {
            var entity = await this.context.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task<List<T>> GetEntities()
        {
            var entities = await this.context.Set<T>().ToListAsync();

            return entities;
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
