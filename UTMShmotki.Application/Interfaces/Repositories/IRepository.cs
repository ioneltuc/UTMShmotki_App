using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : Entity;
        Task<List<T>> GetAllAsync<T>() where T : Entity;
        Task AddEntityAsync<T>(T entity) where T : Entity;
        Task UpdateByIdAsync<T>() where T : Entity;
        Task DeleteByIdAsync<T>(int id) where T : Entity;
    }
}