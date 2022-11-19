using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public string GetToken(UserInfo userInfo);
    }
}