using System.IdentityModel.Tokens.Jwt;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public string GetToken(UserInfo userInfo);
        public JwtSecurityToken VerifyUserLoggedIn(string jwt);
        public UserInfo GetById(int id);
    }
}