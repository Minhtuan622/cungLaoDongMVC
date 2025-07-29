using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }
    // GET
    public IActionResult Signup()
    {
        return View();
    }
    // GET
    public IActionResult ResetPassword()
    {
        return View();
    }
}