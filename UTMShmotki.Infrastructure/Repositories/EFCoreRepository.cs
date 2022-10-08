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

        public void DeleteById<T>(int id) where T : Entity
        {
            var entity = _storeDbContext.Set<T>().Find(id);

            if(entity == null)
            {
                throw new ValidationException($"Object of type {typeof(T)} with id {id} not found");
            }

            _storeDbContext.Set<T>().Remove(entity);
            _storeDbContext.SaveChanges();
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _storeDbContext.Set<T>().ToList();   
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _storeDbContext.Find<T>(id);
        }

        public void UpdateById<T>() where T : Entity
        {
            _storeDbContext.SaveChanges();
        }
    }
}