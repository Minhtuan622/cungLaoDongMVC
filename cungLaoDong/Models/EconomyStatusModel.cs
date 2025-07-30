using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cungLaoDong.Models;

[Table(name: "cung_dm_tinhtrangkinhte")]
public class EconomyStatusModel
{
    [Key] [Column("tinhtrangkinhte_id")] public int Id { get; set; }

    [DisplayName("Tên")]
    [Column("tinhtrangkinhte_ten")]
    public string? Name { get; set; }
}