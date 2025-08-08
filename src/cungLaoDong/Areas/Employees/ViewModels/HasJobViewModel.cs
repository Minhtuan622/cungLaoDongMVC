using cungLaoDong.Areas.Jobs.Models;
using cungLaoDong.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class HasJobViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public JobPositionModel? JobPosition { get; set; }
    public JobModel? Job { get; set; }
    public string? Province { get; set; }
    public string? Weird { get; set; }
    public string? Address { get; set; }
}