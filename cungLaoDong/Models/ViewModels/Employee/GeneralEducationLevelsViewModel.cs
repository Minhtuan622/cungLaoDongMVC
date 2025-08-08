namespace cungLaoDong.Models.ViewModels.Employee;

public class GeneralEducationLevelsViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public EducationLevelModel? EducationLevel { get; set; }
    public ProfessionalQualificationsModel? ProfessionalQualification { get; set; }
    public MajorModel? Major { get; set; }
}