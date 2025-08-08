using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Areas.Employees.Models;

[Table("cung_nguoi_co_viec_lam")]
public class HasJobFormModel
{
    [Key] [Column("ncvl_id")] public int? Id { get; set; }
    [Column("nld_id")] public int? EmployeeId { get; set; }
    [Column("ncvl_vi_the_viec_lam_id")] public int? JobPositionId { get; set; }
    [Column("cong_viec_id")] public int? JobId { get; set; }
    [Column("ncvl_dia_chi_tinh_id")] public int? AddressProvince { get; set; }
    [Column("ncvl_dia_chi_xa_id")] public int? AddressWeird { get; set; }
    [Column("ncvl_dia_chi_chi_tiet")] public string? AddressInfo { get; set; }
}