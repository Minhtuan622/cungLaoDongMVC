using cungLaoDong.Data;
using cungLaoDong.Models;
using cungLaoDong.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        return View(new EmployeeViewModel
        {
            Addresses = await context.AddressModels.ToListAsync(),
            GeneralEducationLevels = await context.GeneralEducationLevelModels.ToListAsync(),
            EducationLevels = await context.EducationLevelModels.ToListAsync(),
            ProfessionalQualifications = await context.ProfessionalQualificationsModels.ToListAsync(),
            Majors = await context.MajorModels.ToListAsync(),
            EconomyStatuses = await context.EconomyStatusModels.ToListAsync(),
            JobPositions = await context.JobPositionModels.ToListAsync(),
            BusinessIndustries = await context.BusinessIndustryModels.ToListAsync(),
            UnemployedTimes = await context.UnemployedTimeModels.ToListAsync(),
            UnemployedReasons = await context.UnemployedReasonModels.ToListAsync(),
            Jobs = await context.JobModels.ToListAsync(),
            People = await context.PeopleModels.ToListAsync(),
            EmployeeForm = new EmployeeFormModel()
        });
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateEmployeeViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model: await GetViewModelWithLookups(viewModel));
            }
            
            var employee = viewModel.EmployeeForm;
            context.EmployeeModels.Add(employee);
            await context.SaveChangesAsync();

            var employeeId = employee.Id;

            if (viewModel.PriorityForm is not null)
            {
                viewModel.PriorityForm.EmployeeId = employeeId;
                viewModel.PriorityForm.Kind = JsonConvert.SerializeObject(viewModel.PriorityKinds);
                context.PriorityFormModels.Add(viewModel.PriorityForm);
            }

            if (viewModel.PriorityKinds is not null)
            {
                var data = new PriorityFormModel
                {
                    EmployeeId = employeeId,
                    Kind = JsonConvert.SerializeObject(viewModel.PriorityKinds)
                };
                context.PriorityFormModels.Add(data);
            }

            if (viewModel.GeneralEducationLevelsForm is not null)
            {
                viewModel.GeneralEducationLevelsForm.EmployeeId = employeeId;
                context.GeneralEducationLevelsFormModels.Add(viewModel.GeneralEducationLevelsForm);
            }

            if (viewModel.HasJobForm is not null)
            {
                viewModel.HasJobForm.EmployeeId = employeeId;
                context.HasJobFormModels.Add(viewModel.HasJobForm);
            }

            if (viewModel.UnemployedForm is not null)
            {
                viewModel.UnemployedForm.EmployeeId = employeeId;
                context.UnemployedFormModels.Add(viewModel.UnemployedForm);
            }

            if (viewModel.StudyingForm is not null)
            {
                viewModel.StudyingForm.EmployeeId = employeeId;
                context.StudyingFormModels.Add(viewModel.StudyingForm);
            }

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // GET
    public IActionResult Edit()
    {
        return View();
    }

    private async Task<EmployeeViewModel> GetViewModelWithLookups(CreateEmployeeViewModel submitted)
    {
        return new EmployeeViewModel
        {
            EmployeeForm = submitted.EmployeeForm,
            PriorityForm = submitted.PriorityForm,
            GeneralEducationLevelsForm = submitted.GeneralEducationLevelsForm,
            HasJobForm = submitted.HasJobForm,
            UnemployedForm = submitted.UnemployedForm,
            StudyingForm = submitted.StudyingForm,

            Addresses = await context.AddressModels.ToListAsync(),
            GeneralEducationLevels = await context.GeneralEducationLevelModels.ToListAsync(),
            EducationLevels = await context.EducationLevelModels.ToListAsync(),
            ProfessionalQualifications = await context.ProfessionalQualificationsModels.ToListAsync(),
            Majors = await context.MajorModels.ToListAsync(),
            EconomyStatuses = await context.EconomyStatusModels.ToListAsync(),
            JobPositions = await context.JobPositionModels.ToListAsync(),
            BusinessIndustries = await context.BusinessIndustryModels.ToListAsync(),
            UnemployedTimes = await context.UnemployedTimeModels.ToListAsync(),
            UnemployedReasons = await context.UnemployedReasonModels.ToListAsync(),
            Jobs = await context.JobModels.ToListAsync(),
            People = await context.PeopleModels.ToListAsync()
        };
    }
}