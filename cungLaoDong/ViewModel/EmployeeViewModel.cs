using cungLaoDong.Models;

namespace cungLaoDong.ViewModel;

public class EmployeeViewModel
{
    public required List<AddressModel> Addresses { get; set; }
    public required List<GeneralEducationLevelModel> GeneralEducationLevels { get; set; }
    public required List<EducationLevelModel> EducationLevels { get; set; }
    public required List<ProfessionalQualificationsModel> ProfessionalQualifications { get; set; }
    public required List<MajorModel> Majors { get; set; }
    public required List<EconomyStatusModel> EconomyStatuses { get; set; }
    public required List<JobPositionModel> JobPositions { get; set; }
    public required List<BusinessIndustryModel> BusinessIndustries { get; set; }
    public required List<UnemployedTimeModel> UnemployedTimes { get; set; }
    public required List<UnemployedReasonModel> UnemployedReasons { get; set; }
    public required List<JobModel> Jobs { get; set; }
    public required List<PeopleModel> People { get; set; }
    public required EmployeeFormModel EmployeeForm { get; set; }
    public PriorityFormModel? PriorityForm { get; set; }
    public GeneralEducationLevelsFormModel? GeneralEducationLevelsForm { get; set; }
    public HasJobFormModel? HasJobForm { get; set; }
    public UnemployedFormModel? UnemployedForm { get; set; }
    public StudyingFormModel? StudyingForm { get; set; }
}
