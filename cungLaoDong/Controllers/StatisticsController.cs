using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class StatisticsController : Controller
{
    // GET
    public IActionResult Reports()
    {
        return View();
    }
}