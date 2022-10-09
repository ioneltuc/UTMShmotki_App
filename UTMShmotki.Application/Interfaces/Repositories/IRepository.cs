using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<T> GetById<T>(int id) where T : Entity;
        Task<List<T>> GetAll<T>() where T : Entity;
        void AddEntity<T>(T entity) where T : Entity;
        Task UpdateById<T>() where T : Entity;
        Task DeleteById<T>(int id) where T : Entity;
    }
}