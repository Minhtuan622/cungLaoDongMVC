using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Areas.Education.Models;

[Table("cung_dm_trinhdophothong")]
public class GeneralEducationLevelModel
{
    [Key] [Column("trinhdophothong_id")] public int Id { get; set; }
    [Column("trinhdophothong_ten")] public string? Name { get; set; }
}