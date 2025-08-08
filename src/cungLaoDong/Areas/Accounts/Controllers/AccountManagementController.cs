using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Areas.Accounts.Controllers;

[Area("Accounts")]
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