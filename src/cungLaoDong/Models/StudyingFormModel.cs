using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("cung_nguoi_dang_di_hoc")]
public class StudyingFormModel
{
    [Key] [Column("nddh_id")] public int? Id { get; set; }
    [Column("nld_id")] public int? EmployeeId { get; set; }
    [Column("nddh_trinh_do_dao_tao_id")] public int? EducationLevel { get; set; }
    [Column("nddh_chuyen_nganh_id")] public int? MajorId { get; set; }
    [Column("nddh_thoi_gian_tot_nghiep")] public DateTime? GraduateTime { get; set; }
}