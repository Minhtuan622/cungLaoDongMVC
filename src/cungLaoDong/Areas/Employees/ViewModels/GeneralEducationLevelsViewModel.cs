using cungLaoDong.Areas.Education.Models;
using cungLaoDong.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class GeneralEducationLevelsViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public EducationLevelModel? EducationLevel { get; set; }
    public ProfessionalQualificationsModel? ProfessionalQualification { get; set; }
    public MajorModel? Major { get; set; }
}