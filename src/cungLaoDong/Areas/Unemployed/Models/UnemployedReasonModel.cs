using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Areas.Unemployed.Models;

[Table(name: "cung_dm_lydokhongthamgia")]
public class UnemployedReasonModel
{
    [Key] [Column("lydokhongthamgia_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("lydokhongthamgia_ten")]
    public string? Name { get; set; }
}