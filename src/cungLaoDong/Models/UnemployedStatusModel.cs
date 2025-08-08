using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_trangthaithatnghiep")]
public class UnemployedStatusModel
{
    [Key] [Column("trangthaithatnghiep_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("trangthaithatnghiep_ten")]
    public string? Name { get; set; }
}