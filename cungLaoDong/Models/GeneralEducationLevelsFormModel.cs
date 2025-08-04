using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("cung_trinh_do_hoc_van")]
public class GeneralEducationLevelsFormModel
{
    [Key] [Column("trinh_do_id")] public int? Id { get; set; }
    [Column("nld_id")] public int? EmployeeId { get; set; }
    [Column("trinh_do_giao_duc_id")] public int? EducationLevelId { get; set; }
    [Column("trinh_do_chuyen_mon_id")] public int? ProfessionalQualificationId { get; set; }
    [Column("trinh_do_chuyen_nganh_id")] public int? MajorId { get; set; }
}