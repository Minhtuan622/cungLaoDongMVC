using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("bhtn_diachi_new")]
public class AddressModel
{
    [Key] [Column("ma_dia_chi")] public int Id { get; set; }
    [Column("ten_dia_chi")] public string? Name { get; set; }
    [Column("ma_dia_chi_cha")] public int? ParentId { get; set; }
    [Column("muc")] public int? Level { get; set; }
    [Column("ma_tat")] public string? StandFor { get; set; }
    [Column("kichhoat")] public int? Active { get; set; }
    [Column("ghichu")] public string? Note { get; set; }
    [Column("mucluongvung")] public int? RegionalSalary { get; set; }
}