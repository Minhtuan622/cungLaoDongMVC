using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_congviec")]
public class JobModel
{
    [Key] [Column("congviec_id")] public int Id { get; set; }

    [DisplayName("Mã ngành")]
    [Column("congviec_ma_nganh")]
    public string? Code { get; set; }

    [DisplayName("Mã cấp")]
    [Column("congviec_ma_cap")]
    public int Level { get; set; }

    [DisplayName("Tên")]
    [Column("congviec_ten")]
    public string? Name { get; set; }

    [DisplayName("Ghi chú")]
    [Column("congviec_ghi_chu")]
    public string? Note { get; set; }
}