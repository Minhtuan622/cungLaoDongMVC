using cungLaoDong.Areas.Education.Models;
using cungLaoDong.Areas.Qualifications.Models;
using cungLaoDong.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class StudyingViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public EducationLevelModel? EducationLevel { get; set; }
    public MajorModel? Major { get; set; }
    public DateTime? GraduateTime { get; set; }
}