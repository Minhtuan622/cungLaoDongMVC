using cungLaoDong.Data;
using cungLaoDong.Areas.Jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Areas.Jobs.Controllers;

[Area("Jobs")]
public class JobPositionController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(model: await context.JobPositionModels.ToListAsync());
    }

    // GET
    public IActionResult Add()
    {
        return View();
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(JobPositionModel model)
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

        var data = await context.FindAsync<JobPositionModel>(keyValues: id);
        if (data is null)
        {
            return NotFound();
        }

        return View(model: data);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, JobPositionModel model)
    {
        var data = await context.FindAsync<JobPositionModel>(keyValues: id);
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
        var data = await context.JobPositionModels.FindAsync(keyValues: id);
        if (data is not null)
        {
            context.JobPositionModels.Remove(entity: data);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }
}