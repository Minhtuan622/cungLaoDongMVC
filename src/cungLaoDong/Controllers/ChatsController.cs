using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class ChatsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}