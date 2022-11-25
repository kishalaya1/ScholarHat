using Microsoft.AspNetCore.Mvc;

namespace ScholarHat.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
