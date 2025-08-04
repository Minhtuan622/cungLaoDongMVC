using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("cung_nhom_uu_tien")]
public class PriorityFormModel
{
    [Key] [Column("uu_tien_id")] public int? Id { get; set; }
    [Column("nld_id")] public int? EmployeeId { get; set; }
    [Column("uu_tien_loai")] public string? Kind { get; set; }
    [Column("uu_tien_ma_dan_toc")] public int? PeopleId { get; set; }
}