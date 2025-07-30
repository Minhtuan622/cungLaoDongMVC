using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace cungLaoDong.Models;

[Table(name: "cung_nguoilaodong")]
public class EmployeeModel
{
    [Key] [Column("nld_id")] public Int32 Id { get; set; }

    [Required(ErrorMessage = "Họ và tên không được trống")]
    [StringLength(255, ErrorMessage = "Họ và tên không được quá 255 ký tự")]
    [DisplayName("Họ và tên")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "CCCD không được trống")]
    [StringLength(12, ErrorMessage = "CCCD không được quá 12 ký tự")]
    [DisplayName("CCCD")]
    public string? Identity { get; set; }

    [Required(ErrorMessage = "Ngày sinh không được trống")]
    [DisplayName("Ngày sinh")]
    public JSType.Date? Birthday { get; set; }

    [Required(ErrorMessage = "Giới tính không được trống")]
    [DisplayName("Giới tính")]
    public Int32 Gender { get; set; }

    [Required(ErrorMessage = "Tỉnh thường trú không được trống")]
    [DisplayName("Tỉnh thường trú")]
    public string? PermanentProvince { get; set; }

    [Required(ErrorMessage = "Phường / xã thường trú không được trống")]
    [DisplayName("Phường / xã thường trú")]
    public string? PermanentWard { get; set; }

    [Required(ErrorMessage = "Địa chỉ thường trú không được trống")]
    [DisplayName("Địa chỉ thường trú")]
    public string? PermanentAddress { get; set; }

    [DisplayName("Tỉnh hiện tại")] public string? TemporaryResidenceProvince { get; set; }

    [DisplayName("Phường / xã hiện tại")] public string? TemporaryResidenceWard { get; set; }

    [DisplayName("Địa chỉ hiện tại")] public string? TemporaryResidenceAddress { get; set; }

    [DisplayName("Tình trạng kinh tế")] public Int32 EconomyStatus { get; set; }

    [DisplayName("Lý do không tham gia hoạt động kinh tế")]
    public Int32 UnemployedReason { get; set; }
}