using cungLaoDong.Data;
using cungLaoDong.Areas.Unemployed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Areas.Unemployed.Controllers;

[Area("Unemployed")]
public class UnemployedStatusController(ApplicationDbContext context) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        return View(model: await context.UnemployedStatusModels.ToListAsync());
    }

    // GET
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(UnemployedStatusModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model: model);
        }

        await context.AddAsync(entity: model);
        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }

    // GET
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var data = await context.FindAsync<UnemployedStatusModel>(keyValues: id);
        if (data is null)
        {
            return NotFound();
        }

        return View(model: data);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UnemployedStatusModel model)
    {
        var data = await context.FindAsync<UnemployedStatusModel>(keyValues: id);
        if (id != data!.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model: model);
        }
        
        data.Name = model.Name;
        context.Update(entity: data);
        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }
    
    [HttpPost, ActionName(name: "Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await context.UnemployedStatusModels.FindAsync(keyValues: id);
        if (data is not null)
        {
            context.UnemployedStatusModels.Remove(entity: data);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }
}