using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_trinhdochuyenmon")]
public class ProfessionalQualificationsModel
{
    [Key] [Column("trinhdochuyenmon_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("trinhdochuyenmon_ten")]
    public string? Name { get; set; }
}