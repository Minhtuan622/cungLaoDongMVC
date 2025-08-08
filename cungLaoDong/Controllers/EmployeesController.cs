using cungLaoDong.Data;
using cungLaoDong.Data.Repositories;
using cungLaoDong.Models;
using cungLaoDong.Models.ViewModels.Employee;
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

            var dataTasks = employees
                .Select(employee => employeeRepository.GetEmployeeInfoByIdAsync(employee.Id));

            var data = await Task.WhenAll(dataTasks);

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
        if (employeeInfo == null)
        {
            return NotFound();
        }

        var employeeData = await employeeRepository.GetEmployeeByIdAsync(employeeInfo.Id);
        if (employeeData == null)
        {
            return NotFound();
        }

        var permanentAddress =
            context.AddressModels.Find(employeeData.PermanentProvince)?.Name +
            context.AddressModels.Find(employeeData.PermanentWard)?.Name +
            context.AddressModels.Find(employeeData.PermanentAddress)?.Name;
        var temporaryResidenceAddress =
            context.AddressModels.Find(employeeData.TemporaryResidenceProvince)?.Name +
            context.AddressModels.Find(employeeData.TemporaryResidenceWard)?.Name +
            context.AddressModels.Find(employeeData.TemporaryResidenceAddress)?.Name;

        var hasJob = context.HasJobFormModels.Find(employeeData.Id);
        var hasJobViewModel = new HasJobViewModel();
        if (hasJob is not null)
        {
            hasJobViewModel.Id = hasJob.Id;
            hasJobViewModel.Job = context.JobModels.Find(hasJob.JobId);
            hasJobViewModel.JobPosition = context.JobPositionModels.Find(hasJob.JobPositionId);
            hasJobViewModel.Employee = employeeInfo;
            hasJobViewModel.Province = context.AddressModels.Find(hasJob.AddressProvince.ToString())?.Name;
            hasJobViewModel.Weird = context.AddressModels.Find(hasJob.AddressWeird.ToString())?.Name;
            hasJobViewModel.Address = context.AddressModels.Find(hasJob.AddressInfo)?.Name;
        }

        var unemployed = context.UnemployedFormModels.Find(employeeData.Id);
        var unemployedViewModel = new UnemployedViewModel();
        if (unemployed is not null)
        {
            unemployedViewModel.Id = unemployed.Id;
            unemployedViewModel.Employee = employeeInfo;
            unemployedViewModel.Time = context.UnemployedTimeModels.Find(unemployed.TimeId);
            unemployedViewModel.Status = unemployed.Status ? "Đã từng làm việc" : "Chưa từng làm việc";
            unemployedViewModel.Demand = unemployed.Demand;
        }

        var priority = context.PriorityFormModels.Find(employeeData.Id);
        var priorityViewModel = new PriorityViewModel();
        if (priority is not null)
        {
            priorityViewModel.Id = priority.Id;
            priorityViewModel.Employee = employeeInfo;
            if (priority.Kind is not null)
            {
                priorityViewModel.Kind = JsonConvert.DeserializeObject<List<int>>(priority.Kind);
            }

            priorityViewModel.People = context.PeopleModels.Find(priority.PeopleId);
        }

        var education = context.GeneralEducationLevelsFormModels.Find(employeeData.Id);
        var generalEducationLevels = new GeneralEducationLevelsViewModel();
        if (education is not null)
        {
            generalEducationLevels.Id = education.Id;
            generalEducationLevels.Employee = employeeInfo;
            generalEducationLevels.EducationLevel = context.EducationLevelModels.Find(education.EducationLevelId);
            generalEducationLevels.ProfessionalQualification =
                context.ProfessionalQualificationsModels.Find(education.ProfessionalQualificationId);
            generalEducationLevels.Major = context.MajorModels.Find(education.MajorId);
        }

        var studying = context.StudyingFormModels.Find(employeeData.Id);
        var studyingViewModel = new StudyingViewModel();
        if (studying is not null)
        {
            studyingViewModel.Id = studying.Id;
            studyingViewModel.Employee = employeeInfo;
            studyingViewModel.EducationLevel = context.EducationLevelModels.Find(studying.EducationLevel);
            studyingViewModel.GraduateTime = studying.GraduateTime;
            studyingViewModel.Major = context.MajorModels.Find(studying.MajorId);
        }

        var data = new ShowEmployeeViewModel
        {
            EmployeeInfo = employeeInfo,
            BusinessIndustry = context.BusinessIndustryModels.Find(employeeData.Id),
            EconomyStatus = context.EconomyStatusModels.Find(employeeData.Id),
            EducationLevel = context.EducationLevelModels.Find(employeeData.Id),
            GeneralEducationLevel = context.GeneralEducationLevelModels.Find(employeeData.Id),
            Job = context.JobModels.Find(employeeData.Id),
            JobPosition = context.JobPositionModels.Find(employeeData.Id),
            Major = context.MajorModels.Find(employeeData.Id),
            People = context.PeopleModels.Find(employeeData.Id),
            ProfessionalQualification = context.ProfessionalQualificationsModels.Find(employeeData.Id),
            UnemployedReason = context.UnemployedReasonModels.Find(employeeData.UnemployedReason),
            UnemployedTime = context.UnemployedTimeModels.Find(employeeData.Id),
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