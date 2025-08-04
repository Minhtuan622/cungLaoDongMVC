using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("bhtn_diachi_new")]
public class AddressModel
{
    [Key] [Column("ma_dia_chi")] public string Id { get; set; }
    [Column("ten_dia_chi")] public string? Name { get; set; }
    [Column("ma_dia_chi_cha")] public string? ParentId { get; set; }
    [Column("muc")] public byte? Level { get; set; }
    [Column("ma_tat")] public string? StandFor { get; set; }
    [Column("kichhoat")] public bool? Active { get; set; }
    [Column("ghichu")] public string? Note { get; set; }
    [Column("mucluongvung")] public int? RegionalSalary { get; set; }
}