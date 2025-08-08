namespace cungLaoDong.Models.ViewModels.Employee;

public class PriorityViewModel
{
    public int? Id { get; set; }
    public EmployeeInfoViewModel? Employee { get; set; }
    public List<int>? Kind { get; set; }
    public PeopleModel? People { get; set; }
}