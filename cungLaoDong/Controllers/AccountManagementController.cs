using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class AccountManagementController : Controller
{
    // GET
    public IActionResult Admin()
    {
        return View();
    }
    // GET
    public IActionResult AddAdmin()
    {
        return View();
    }
}