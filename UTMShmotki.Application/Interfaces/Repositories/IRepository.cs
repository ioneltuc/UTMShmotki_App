using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity;
        List<T> GetAll<T>() where T : Entity;
        void AddEntity<T>(T entity) where T : Entity;
        void UpdateById<T>() where T : Entity;
        void DeleteById<T>(int id) where T : Entity;
    }
}