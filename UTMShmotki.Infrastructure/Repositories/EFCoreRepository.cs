using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;
using UTMShmotki.Infrastructure.Contexts;

namespace UTMShmotki.Infrastructure.Repositories
{
    public class EFCoreRepository : IRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public EFCoreRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void AddEntity<T>(T entity) where T : Entity
        {
            _storeDbContext.Set<T>().Add(entity);
            _storeDbContext.SaveChanges();
        }

        public async Task DeleteById<T>(int id) where T : Entity
        {
            var entity = await _storeDbContext.Set<T>().FindAsync(id);

            if(entity == null)
            {
                throw new ValidationException($"Object of type {typeof(T)} with id {id} not found");
            }

            _storeDbContext.Set<T>().Remove(entity);
            _storeDbContext.SaveChanges();
        }

        public async Task<List<T>> GetAll<T>() where T : Entity
        {
            return await _storeDbContext.Set<T>().ToListAsync();   
        }

        public async Task<T> GetById<T>(int id) where T : Entity
        {
            return await _storeDbContext.FindAsync<T>(id);
        }

        public async Task UpdateById<T>() where T : Entity
        {
            await _storeDbContext.SaveChangesAsync();
        }
    }
}