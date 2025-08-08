using cungLaoDong.Data;
using cungLaoDong.Areas.Qualifications.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Areas.Qualifications.Controllers;

[Area("Qualifications")]
public class MajorController(ApplicationDbContext context) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        return View(model: await context.MajorModels.ToListAsync());
    }

    // GET
    public IActionResult Add()
    {
        return View();
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(MajorModel model)
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

        var data = await context.FindAsync<MajorModel>(keyValues: id);
        if (data is null)
        {
            return NotFound();
        }

        return View(model: data);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MajorModel model)
    {
        var data = await context.FindAsync<MajorModel>(keyValues: id);
        if (id != data!.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model: model);
        }
        
        data.Code = model.Code;
        data.Level =  model.Level;
        data.Name = model.Name;
        data.Note = model.Note;
        context.Update(entity: data);
        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }
    
    [HttpPost, ActionName(name: "Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await context.MajorModels.FindAsync(keyValues: id);
        if (data is not null)
        {
            context.MajorModels.Remove(entity: data);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(actionName: nameof(Index));
    }
}