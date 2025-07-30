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

    // GET
    public IActionResult ProfessionalQualifications()
    {
        return View(model: context.ProfessionalQualificationsModels.ToList());
    }

    // GET
    public IActionResult EconomyStatus()
    {
        return View(model: context.EconomyStatusModels.ToList());
    }

    // GET
    public IActionResult UnemployedReason()
    {
        return View(model:context.UnemployedReasonModels.ToList());
    }

    // GET
    public IActionResult JobPosition()
    {
        return View(model:context.JobPositionModels.ToList());
    }

    // GET
    public IActionResult UnemployedStatus()
    {
        return View(model:context.UnemployedStatusModels.ToList());
    }

    // GET
    public IActionResult UnemployedTime()
    {
        return View(model:context.UnemployedTimeModels.ToList());
    }
}