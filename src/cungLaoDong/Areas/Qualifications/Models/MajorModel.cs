using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Areas.Qualifications.Models;

[Table(name: "cung_dm_chuyennganhdaotao")]
public class MajorModel
{
    [Key] [Column("chuyennganhdaotao_id")] public int Id { get; set; }

    [DisplayName("Mã ngành")]
    [Column("chuyennganhdaotao_ma_nganh")]
    public string? Code { get; set; }

    [DisplayName("Mã cấp")]
    [Column("chuyennganhdaotao_ma_cap")]
    public int Level { get; set; }

    [DisplayName("Tên")]
    [Column("chuyennganhdaotao_ten")]
    public string? Name { get; set; }

    [DisplayName("Ghi chú")]
    [Column("chuyennganhdaotao_ghi_chu")]
    public string? Note { get; set; }
}