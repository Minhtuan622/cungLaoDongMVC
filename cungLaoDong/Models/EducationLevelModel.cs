using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("cung_dm_trinhdodaotao")]
public class EducationLevelModel
{
    [Key] [Column("trinhdodaotao_id")] public int Id { get; set; }
    [Column("trinhdodaotao_ten")] public string? Name { get; set; }
}