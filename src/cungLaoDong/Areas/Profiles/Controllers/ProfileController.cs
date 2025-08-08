using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Areas.Profiles.Controllers;

[Area("Profiles")]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Update()
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
