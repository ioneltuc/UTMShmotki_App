using Microsoft.AspNetCore.Mvc;
using UTMShmotki.Application.App.User.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = new UserInfo()
            {
                UserName = loginDto.UserName,
                Password = loginDto.Password,
            };

            var jwt = _userRepository.GetToken(user);

            if (jwt == null)
            {
                return BadRequest(new
                {
                    message = "Invalid Credentials"
                });
            }

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Success"
            });
        }
    }
}