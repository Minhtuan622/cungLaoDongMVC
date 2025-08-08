using cungLaoDong.Models;
using cungLaoDong.Models.ViewModels.Employee;
using Microsoft.EntityFrameworkCore;

namespace cungLaoDong.Data.Repositories;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<EmployeeFormModel>> GetAllEmployeesAsync()
    {
        return await context.EmployeeModels.ToListAsync();
    }

    public async Task<EmployeeFormModel?> GetEmployeeByIdAsync(int id)
    {
        return await context.EmployeeModels.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<EmployeeInfoViewModel> GetEmployeeInfoByIdAsync(int id)
    {
        var employee = await GetEmployeeByIdAsync(id);
        if (employee is null)
        {
            return new EmployeeInfoViewModel();
        }

        return new EmployeeInfoViewModel
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Birthday = employee.Birthday,
            Gender = employee.Gender ? "Nam" : "Nữ",
            Identity = employee.Identity,
            PermanentAddress = employee.PermanentAddress,
            TemporaryResidenceAddress = employee.TemporaryResidenceAddress,
            EconomyStatus = context.EconomyStatusModels.Find(employee.EconomyStatus),
            UnemployedReason = context.UnemployedReasonModels.Find(employee.UnemployedReason)
        };
    }

    public async Task<IEnumerable<EmployeeFormModel>> GetEmployeesByFilterAsync(EmployeeFilterModel filter)
    {
        var query = context.EmployeeModels.AsQueryable();

        // Apply filters based on actual model properties
        if (!string.IsNullOrEmpty(filter.TinhTrangHoatDong))
        {
            // Filter by EconomyStatus (assuming it's an enum or we need to map values)
            // This would need to be adjusted based on your actual data structure
        }

        if (filter.GioiTinh is not null)
        {
            query = filter.GioiTinh switch
            {
                // Filter by Gender (true = Male, false = Female)
                true => query.Where(e => e.Gender == true),
                false => query.Where(e => e.Gender == false),
                _ => query
            };
        }

        if (!string.IsNullOrEmpty(filter.TinhTp))
        {
            query = query.Where(e => e.PermanentProvince != null && e.PermanentProvince.Contains(filter.TinhTp));
        }

        if (!string.IsNullOrEmpty(filter.TamTru))
        {
            query = query.Where(e => e.TemporaryResidenceProvince != null && e.TemporaryResidenceProvince.Contains(filter.TamTru));
        }

        return await query.ToListAsync();
    }

    public async Task<EmployeeFormModel> AddEmployeeAsync(EmployeeFormModel employee)
    {
        context.EmployeeModels.Add(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<EmployeeFormModel> UpdateEmployeeAsync(EmployeeFormModel employee)
    {
        context.EmployeeModels.Update(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await context.Database.ExecuteSqlRawAsync("DELETE FROM cung_nguoilaodong WHERE nld_id = {0}", id);
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await context.EmployeeModels.CountAsync();
    }
} 