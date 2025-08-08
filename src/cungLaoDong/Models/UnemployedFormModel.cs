using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("cung_nguoi_that_nghiep")]
public class UnemployedFormModel
{
    [Key] [Column("ntn_id")]  public int? Id { get; set; }
    [Column("nld_id")] public int? EmployeeId { get; set; }
    [Column("ntn_trang_thai")] public bool Status { get; set; }
    [Column("ntn_thoi_gian_that_nghiep_id")] public int? TimeId { get; set; }
    [Column("ntn_nhu_cau_viec_lam")] public string? Demand { get; set; }
}