using cungLaoDong.Areas.Education.Models;
using cungLaoDong.Models;
using cungLaoDong.Areas.Unemployed.Models;
using cungLaoDong.Areas.Jobs.Models;
using cungLaoDong.Areas.Qualifications.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class ShowEmployeeViewModel
{
    public EmployeeInfoViewModel? EmployeeInfo { get; set; }
    public string? PermanentAddress { get; set; }
    public string? TemporaryResidenceAddress { get; set; }
    public GeneralEducationLevelModel? GeneralEducationLevel { get; set; }
    public EducationLevelModel? EducationLevel { get; set; }
    public ProfessionalQualificationsModel? ProfessionalQualification { get; set; }
    public MajorModel? Major { get; set; }
    public EconomyStatusModel? EconomyStatus { get; set; }
    public JobPositionModel? JobPosition { get; set; }
    public BusinessIndustryModel? BusinessIndustry { get; set; }
    public UnemployedTimeModel? UnemployedTime { get; set; }
    public UnemployedReasonModel? UnemployedReason { get; set; }
    public JobModel? Job { get; set; }
    public PeopleModel? People { get; set; }
    public HasJobViewModel? HasJob { get; set; }
    public UnemployedViewModel? Unemployed { get; set; }
    public PriorityViewModel? Priority { get; set; }
    public GeneralEducationLevelsViewModel? GeneralEducationLevels { get; set; }
    public StudyingViewModel? Studying { get; set; }
}
