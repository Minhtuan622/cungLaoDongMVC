namespace cungLaoDong.Models.ViewModels.Employee;

public class StudyingViewModel
{
    public int? Id { get; set; }
    public Task<EmployeeInfoViewModel>? Employee { get; set; }
    public EducationLevelModel? EducationLevel { get; set; }
    public MajorModel? Major { get; set; }
    public DateTime? GraduateTime { get; set; }
}