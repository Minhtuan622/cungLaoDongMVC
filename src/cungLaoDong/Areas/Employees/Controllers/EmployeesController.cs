using cungLaoDong.Data;
using cungLaoDong.Areas.Employees.Models;
using cungLaoDong.Areas.Employees.Repositories;
using cungLaoDong.Areas.Employees.ViewModels;
using cungLaoDong.Areas.Unemployed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace cungLaoDong.Areas.Employees.Controllers;

 [Area("Employees")]
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

            var data = new List<EmployeeInfoViewModel>();
            foreach (var employee in employees)
            {
                var info = await employeeRepository.GetEmployeeInfoByIdAsync(employee.Id);
                data.Add(info);
            }

            return View(data);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading employees");
            return View();
        }
    }

    public async Task<IActionResult> Show(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employeeInfo = await employeeRepository.GetEmployeeInfoByIdAsync(id.Value);

        var employeeData = await employeeRepository.GetEmployeeByIdAsync(employeeInfo.Id);
        if (employeeData == null)
        {
            return NotFound();
        }

        var permanentAddress =
            (await context.AddressModels.FindAsync(employeeData.PermanentProvince))?.Name +
            (await context.AddressModels.FindAsync(employeeData.PermanentWard))?.Name +
            (await context.AddressModels.FindAsync(employeeData.PermanentAddress))?.Name;
        var temporaryResidenceAddress =
            (await context.AddressModels.FindAsync(employeeData.TemporaryResidenceProvince))?.Name +
            (await context.AddressModels.FindAsync(employeeData.TemporaryResidenceWard))?.Name +
            (await context.AddressModels.FindAsync(employeeData.TemporaryResidenceAddress))?.Name;

        var hasJob = await context.HasJobFormModels.FindAsync(employeeData.Id);
        var hasJobViewModel = new HasJobViewModel();
        if (hasJob is not null)
        {
            hasJobViewModel.Id = hasJob.Id;
            hasJobViewModel.Job = await context.JobModels.FindAsync(hasJob.JobId);
            hasJobViewModel.JobPosition = await context.JobPositionModels.FindAsync(hasJob.JobPositionId);
            hasJobViewModel.Employee = employeeInfo;
            hasJobViewModel.Province = (await context.AddressModels.FindAsync(hasJob.AddressProvince.ToString()))?.Name;
            hasJobViewModel.Weird = (await context.AddressModels.FindAsync(hasJob.AddressWeird.ToString()))?.Name;
            hasJobViewModel.Address = (await context.AddressModels.FindAsync(hasJob.AddressInfo))?.Name;
        }

        var unemployed = await context.UnemployedFormModels.FindAsync(employeeData.Id);
        var unemployedViewModel = new UnemployedViewModel();
        if (unemployed is not null)
        {
            unemployedViewModel.Id = unemployed.Id;
            unemployedViewModel.Employee = employeeInfo;
            unemployedViewModel.Time = await context.UnemployedTimeModels.FindAsync(unemployed.TimeId);
            unemployedViewModel.Status = unemployed.Status ? "Đã từng làm việc" : "Chưa từng làm việc";
            unemployedViewModel.Demand = unemployed.Demand;
        }

        var priority = await context.PriorityFormModels.FindAsync(employeeData.Id);
        var priorityViewModel = new PriorityViewModel();
        if (priority is not null)
        {
            priorityViewModel.Id = priority.Id;
            priorityViewModel.Employee = employeeInfo;
            if (priority.Kind is not null)
            {
                priorityViewModel.Kind = JsonConvert.DeserializeObject<List<int>>(priority.Kind);
            }

            priorityViewModel.People = await context.PeopleModels.FindAsync(priority.PeopleId);
        }

        var education = await context.GeneralEducationLevelsFormModels.FindAsync(employeeData.Id);
        var generalEducationLevels = new GeneralEducationLevelsViewModel();
        if (education is not null)
        {
            generalEducationLevels.Id = education.Id;
            generalEducationLevels.Employee = employeeInfo;
            generalEducationLevels.EducationLevel = await context.EducationLevelModels.FindAsync(education.EducationLevelId);
            generalEducationLevels.ProfessionalQualification =
                await context.ProfessionalQualificationsModels.FindAsync(education.ProfessionalQualificationId);
            generalEducationLevels.Major = await context.MajorModels.FindAsync(education.MajorId);
        }

        var studying = await context.StudyingFormModels.FindAsync(employeeData.Id);
        var studyingViewModel = new StudyingViewModel();
        if (studying is not null)
        {
            studyingViewModel.Id = studying.Id;
            studyingViewModel.Employee = employeeInfo;
            studyingViewModel.EducationLevel = await context.EducationLevelModels.FindAsync(studying.EducationLevel);
            studyingViewModel.GraduateTime = studying.GraduateTime;
            studyingViewModel.Major = await context.MajorModels.FindAsync(studying.MajorId);
        }

        var data = new ShowEmployeeViewModel
        {
            EmployeeInfo = employeeInfo,
            BusinessIndustry = await context.BusinessIndustryModels.FindAsync(employeeData.Id),
            EconomyStatus = await context.EconomyStatusModels.FindAsync(employeeData.Id),
            EducationLevel = await context.EducationLevelModels.FindAsync(employeeData.Id),
            GeneralEducationLevel = await context.GeneralEducationLevelModels.FindAsync(employeeData.Id),
            Job = await context.JobModels.FindAsync(employeeData.Id),
            JobPosition = await context.JobPositionModels.FindAsync(employeeData.Id),
            Major = await context.MajorModels.FindAsync(employeeData.Id),
            People = await context.PeopleModels.FindAsync(employeeData.Id),
            ProfessionalQualification = await context.ProfessionalQualificationsModels.FindAsync(employeeData.Id),
            UnemployedReason = await context.UnemployedReasonModels.FindAsync(employeeData.UnemployedReason),
            UnemployedTime = await context.UnemployedTimeModels.FindAsync(employeeData.Id),
            PermanentAddress = permanentAddress,
            TemporaryResidenceAddress = temporaryResidenceAddress,
            HasJob = hasJobViewModel,
            Unemployed = unemployedViewModel,
            Priority = priorityViewModel,
            GeneralEducationLevels = generalEducationLevels,
            Studying = studyingViewModel
        };

        return View(data);
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

    private async Task<EmployeeFormViewModel> CreateEmployeeViewModel(int? employeeId = null)
    {
        var viewModel = new EmployeeFormViewModel
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

    private async Task<EmployeeFormViewModel> GetViewModelWithLookups(CreateEmployeeViewModel submitted)
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