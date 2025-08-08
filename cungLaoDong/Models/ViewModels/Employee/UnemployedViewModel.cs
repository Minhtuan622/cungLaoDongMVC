namespace cungLaoDong.Models.ViewModels.Employee;

public class UnemployedViewModel
{
    public int? Id { get; set; }
    public Task<EmployeeInfoViewModel>? Employee { get; set; }
    public string? Status { get; set; }
    public UnemployedTimeModel? Time { get; set; }
    public string? Demand { get; set; }
}