using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_thoigianthatnghiep")]
public class UnemployedTimeModel
{
    [Key] [Column("thoigianthatnghiep_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("thoigianthatnghiep_ten")]
    public string? Name { get; set; }
}