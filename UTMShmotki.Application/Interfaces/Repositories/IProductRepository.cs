using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<List<Product>> GetPaginatedAsync(int pageNumber, int pageSize, string searchString, string sortType);
    }
}