using Code.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Core;
namespace AuthService.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usermodel login)
        {
            IActionResult response = Unauthorized();
            var user = Usermethods.AuthenticateUser(login);

            if (user.Status == "Success")
            {
                var tokenString = Usermethods.GenerateJSONWebToken(user, _config["Jwt:Key"], _config["Jwt:Audience"], _config["Jwt:Issuer"]);
                response = Ok(new { token = tokenString });
            }
            else
            {
                response = Unauthorized();
            }

            return response;
        }
    }
}
