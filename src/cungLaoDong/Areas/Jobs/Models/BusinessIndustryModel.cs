using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Areas.Jobs.Models;

[Table(name: "cung_dm_nganhnghekinhdoanh")]

public class BusinessIndustryModel
{
    [Key] [Column("nganhnghe_id")] public int Id { get; set; }

    [DisplayName("Mã ngành")]
    [Column("nganhnghe_ma_nganh")]
    public string? Code { get; set; }

    [DisplayName("Mã cấp")]
    [Column("nganhnghe_ma_cap")]
    public int Level { get; set; }

    [DisplayName("Tên")]
    [Column("nganhnghe_ten")]
    public string? Name { get; set; }

    [DisplayName("Ghi chú")]
    [Column("nganhnghe_ghi_chu")]
    public string? Note { get; set; }
}