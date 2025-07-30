using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_vithevieclam")]
public class JobPositionModel
{
    [Key] [Column("vithevieclam_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("vithevieclam_ten")]
    public string? Name { get; set; }
}