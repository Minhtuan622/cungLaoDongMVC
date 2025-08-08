using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table("bhtn_dm_dantoc")]
public class PeopleModel
{
    [Key] [Column("dantoc_id")] public int Id { get; set; }
    [Column("dantoc_ten")] public string? Name { get; set; }
}