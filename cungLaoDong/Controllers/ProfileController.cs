using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult ActivityLog()
        {
            return View();
        }
    }
}
