using cungLaoDong.Models;

namespace cungLaoDong.ViewModel;

public class CreateEmployeeViewModel
{
    public required EmployeeFormModel EmployeeForm { get; set; }
    public PriorityFormModel? PriorityForm { get; set; }
    public GeneralEducationLevelsFormModel? GeneralEducationLevelsForm { get; set; }
    public HasJobFormModel? HasJobForm { get; set; }
    public UnemployedFormModel? UnemployedForm { get; set; }
    public StudyingFormModel? StudyingForm { get; set; }
    public List<int>? PriorityKinds { get; set; }
}