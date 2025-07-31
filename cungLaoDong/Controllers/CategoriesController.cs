using cungLaoDong.Data;
using Microsoft.AspNetCore.Mvc;

namespace cungLaoDong.Controllers;

public class CategoriesController(ApplicationDbContext context) : Controller
{
    // GET
    public IActionResult Major()
    {
        return View(model: context.MajorModels.ToList());
    }

    // GET
    public IActionResult Jobs()
    {
        return View(model: context.JobModels.ToList());
    }

    // GET
    public IActionResult BusinessIndustry()
    {
        return View(model: context.BusinessIndustryModels.ToList());
    }

    // GET
    public IActionResult Add()
    {
        return View();
    }
}