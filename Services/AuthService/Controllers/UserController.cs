using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usermodel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user.Status == "Success")
            {
                var tokenString = GenerateJSONWebToken(user);
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
