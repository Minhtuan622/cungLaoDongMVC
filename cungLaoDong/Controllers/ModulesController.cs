using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class ModulesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    // GET
    public IActionResult Add()
    {
        return View();
    }
}