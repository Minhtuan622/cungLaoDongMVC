using cungLaoDong.Models;

namespace cungLaoDong.Areas.Employees.ViewModels;

public class EmployeeInfoViewModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Identity { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Gender { get; set; }
    public string? PermanentAddress { get; set; }
    public string? TemporaryResidenceAddress { get; set; }
    public EconomyStatusModel? EconomyStatus { get; set; }
    public UnemployedReasonModel? UnemployedReason { get; set; }
}