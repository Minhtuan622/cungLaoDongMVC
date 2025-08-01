using cungLaoDong.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Controllers;

public class EmployeesController(ApplicationDbContext context) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    // GET
    public IActionResult Show()
    {
        return View();
    }

    // GET
    public async Task<IActionResult> Add()
    {
        // var address = await context.AddressModels.ToListAsync();
        var pq = await context.ProfessionalQualificationsModels.ToListAsync();
        var major = await context.MajorModels.ToListAsync();
        var economyStatus = await context.EconomyStatusModels.ToListAsync();
        
        return View();
    }

    // GET
    public IActionResult Edit()
    {
        return View();
    }
}