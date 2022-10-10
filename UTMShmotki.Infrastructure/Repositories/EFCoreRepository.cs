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

        public async Task AddEntityAsync<T>(T entity) where T : Entity
        {
            await _storeDbContext.Set<T>().AddAsync(entity);
            await _storeDbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync<T>(int id) where T : Entity
        {
            var entity = await _storeDbContext.Set<T>().FindAsync(id);

            if(entity == null)
            {
                throw new ValidationException($"Object of type {typeof(T)} with id {id} not found");
            }

            _storeDbContext.Set<T>().Remove(entity);
            await _storeDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : Entity
        {
            return await _storeDbContext.Set<T>().ToListAsync();   
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            var entity = await _storeDbContext.FindAsync<T>(id);

            if (entity == null)
            {
                throw new ValidationException($"Object of type {typeof(T)} with id {id} not found");
            }

            return entity;
        }

        public async Task UpdateByIdAsync<T>() where T : Entity
        {
            await _storeDbContext.SaveChangesAsync();
        }
    }
}