using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
