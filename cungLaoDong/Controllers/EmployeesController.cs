using cungLaoDong.Data;
using cungLaoDong.Data.Repositories;
using cungLaoDong.Models;
using cungLaoDong.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace cungLaoDong.Controllers;

public class EmployeesController(
    ApplicationDbContext context,
    IEmployeeRepository employeeRepository,
    ILogger<EmployeesController> logger)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            var employees = await employeeRepository.GetAllEmployeesAsync();
            return View(employees);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading employees");
            return View(new List<EmployeeFormModel>());
        }
    }

    public IActionResult Show()
    {
        return View();
    }

    public async Task<IActionResult> Add()
    {
        var viewModel = await CreateEmployeeViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(CreateEmployeeViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var updatedViewModel = await GetViewModelWithLookups(viewModel);
            return View(updatedViewModel);
        }

        try
        {
            var employeeId = await CreateEmployee(viewModel);
            await CreateRelatedForms(viewModel, employeeId);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating employee");
            ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi tạo nhân viên. Vui lòng thử lại.");

            var updatedViewModel = await GetViewModelWithLookups(viewModel);
            return View(updatedViewModel);
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        var viewModel = await CreateEmployeeViewModel(id);
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CreateEmployeeViewModel viewModel)
    {
        if (id != viewModel.EmployeeForm.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            var updatedViewModel = await GetViewModelWithLookups(viewModel);
            return View(updatedViewModel);
        }

        try
        {
            await UpdateEmployee(viewModel);
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await EmployeeExists(viewModel.EmployeeForm.Id))
            {
                return NotFound();
            }

            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating employee with id {EmployeeId}", id);
            ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật nhân viên. Vui lòng thử lại.");

            var updatedViewModel = await GetViewModelWithLookups(viewModel);
            return View(updatedViewModel);
        }
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (!await EmployeeExists(id))
            {
                return NotFound();
            }

            await employeeRepository.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting employee with id {EmployeeId}", id);
            TempData["Error"] = "Có lỗi xảy ra khi xóa nhân viên. Vui lòng thử lại.";
            return RedirectToAction(nameof(Index));
        }
    }

    #region Private Methods

    private async Task<int> CreateEmployee(CreateEmployeeViewModel viewModel)
    {
        await employeeRepository.AddEmployeeAsync(viewModel.EmployeeForm);
        return viewModel.EmployeeForm.Id;
    }

    private async Task CreateRelatedForms(CreateEmployeeViewModel viewModel, int employeeId)
    {
        await CreatePriorityForm(viewModel, employeeId);
        CreateGeneralEducationLevelsForm(viewModel, employeeId);
        CreateHasJobForm(viewModel, employeeId);
        CreateUnemployedForm(viewModel, employeeId);
        CreateStudyingForm(viewModel, employeeId);
    }

    private Task CreatePriorityForm(CreateEmployeeViewModel viewModel, int employeeId)
    {
        if (viewModel.PriorityForm != null)
        {
            viewModel.PriorityForm.EmployeeId = employeeId;
            viewModel.PriorityForm.Kind = JsonConvert.SerializeObject(viewModel.PriorityKinds);
            context.PriorityFormModels.Add(viewModel.PriorityForm);
        }
        else if (viewModel.PriorityKinds != null)
        {
            var priorityForm = new PriorityFormModel
            {
                EmployeeId = employeeId,
                Kind = JsonConvert.SerializeObject(viewModel.PriorityKinds)
            };
            context.PriorityFormModels.Add(priorityForm);
        }

        return Task.CompletedTask;
    }

    private void CreateGeneralEducationLevelsForm(CreateEmployeeViewModel viewModel, int employeeId)
    {
        if (viewModel.GeneralEducationLevelsForm != null)
        {
            viewModel.GeneralEducationLevelsForm.EmployeeId = employeeId;
            context.GeneralEducationLevelsFormModels.Add(viewModel.GeneralEducationLevelsForm);
        }
    }

    private void CreateHasJobForm(CreateEmployeeViewModel viewModel, int employeeId)
    {
        if (viewModel.HasJobForm != null)
        {
            viewModel.HasJobForm.EmployeeId = employeeId;
            context.HasJobFormModels.Add(viewModel.HasJobForm);
        }
    }

    private void CreateUnemployedForm(CreateEmployeeViewModel viewModel, int employeeId)
    {
        if (viewModel.UnemployedForm != null)
        {
            viewModel.UnemployedForm.EmployeeId = employeeId;
            context.UnemployedFormModels.Add(viewModel.UnemployedForm);
        }
    }

    private void CreateStudyingForm(CreateEmployeeViewModel viewModel, int employeeId)
    {
        if (viewModel.StudyingForm != null)
        {
            viewModel.StudyingForm.EmployeeId = employeeId;
            context.StudyingFormModels.Add(viewModel.StudyingForm);
        }
    }

    private async Task UpdateEmployee(CreateEmployeeViewModel viewModel)
    {
        if (viewModel.PriorityForm != null)
        {
            viewModel.PriorityForm.Kind = JsonConvert.SerializeObject(viewModel.PriorityKinds);
        }

        await employeeRepository.UpdateEmployeeAsync(viewModel.EmployeeForm);
    }

    private async Task<bool> EmployeeExists(int id)
    {
        var employee = await employeeRepository.GetEmployeeByIdAsync(id);
        return employee != null;
    }

    private async Task<EmployeeViewModel> CreateEmployeeViewModel(int? employeeId = null)
    {
        var viewModel = new EmployeeViewModel
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
            EmployeeForm = new EmployeeFormModel(),
            SelectedPriorityKinds = []
        };

        if (!employeeId.HasValue)
        {
            return viewModel;
        }

        var existingEmployee = await employeeRepository.GetEmployeeByIdAsync(employeeId.Value);
        if (existingEmployee == null)
        {
            return viewModel;
        }

        viewModel.EmployeeForm = existingEmployee;
        viewModel.GeneralEducationLevelsForm = await context.GeneralEducationLevelsFormModels
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId.Value);
        viewModel.PriorityForm = await context.PriorityFormModels
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId.Value);
        viewModel.HasJobForm = await context.HasJobFormModels
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId.Value);
        viewModel.UnemployedForm = await context.UnemployedFormModels
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId.Value);
        viewModel.StudyingForm = await context.StudyingFormModels
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId.Value);

        if (viewModel.PriorityForm?.Kind == null)
        {
            return viewModel;
        }

        try
        {
            viewModel.SelectedPriorityKinds =
                JsonConvert.DeserializeObject<List<int>>(viewModel.PriorityForm.Kind) ?? [];
        }
        catch (JsonException ex)
        {
            logger.LogWarning(ex, "Failed to parse PriorityKinds JSON for employee {EmployeeId}", employeeId);
            viewModel.SelectedPriorityKinds = [];
        }

        return viewModel;
    }

    private async Task<EmployeeViewModel> GetViewModelWithLookups(CreateEmployeeViewModel submitted)
    {
        var viewModel = await CreateEmployeeViewModel();

        // Copy the submitted form data
        viewModel.EmployeeForm = submitted.EmployeeForm;
        viewModel.PriorityForm = submitted.PriorityForm;
        viewModel.GeneralEducationLevelsForm = submitted.GeneralEducationLevelsForm;
        viewModel.HasJobForm = submitted.HasJobForm;
        viewModel.UnemployedForm = submitted.UnemployedForm;
        viewModel.StudyingForm = submitted.StudyingForm;

        return viewModel;
    }

    #endregion
}