using cungLaoDong.Models;

namespace cungLaoDong.Data.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeFormModel>> GetAllEmployeesAsync();
    Task<EmployeeFormModel?> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<EmployeeFormModel>> GetEmployeesByFilterAsync(EmployeeFilterModel filter);
    Task<EmployeeFormModel> AddEmployeeAsync(EmployeeFormModel employee);
    Task<EmployeeFormModel> UpdateEmployeeAsync(EmployeeFormModel employee);
    Task DeleteEmployeeAsync(int id);
    Task<int> GetTotalCountAsync();
}

public class EmployeeFilterModel
{
    public string? TinhTrangHoatDong { get; set; }
    public string? TrinhDoChuyenMon { get; set; }
    public bool? GioiTinh { get; set; }
    public string? DoTuoi { get; set; }
    public string? TinhTp { get; set; }
    public string? DoiTuongUuTien { get; set; }
    public string? TamTru { get; set; }
    public string? TrinhDoPhoThong { get; set; }
    public string? ChuyenNganhDaoTao { get; set; }
    public string? ViTheViecLam { get; set; }
    public string? CongViec { get; set; }
    public string? NoiLamViec { get; set; }
    public string? ThoiGianThatNghiep { get; set; }
    public string? NhuCauViecLam { get; set; }
    public string? TrinhDoDaoTaoHienTai { get; set; }
    public string? ChuyenNganhHienTai { get; set; }
    public string? ThoiGianTotNghiep { get; set; }
} 