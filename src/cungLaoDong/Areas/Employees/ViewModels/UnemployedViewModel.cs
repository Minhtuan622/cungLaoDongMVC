using cungLaoDong.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class UnemployedViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public string? Status { get; set; }
    public UnemployedTimeModel? Time { get; set; }
    public string? Demand { get; set; }
}