using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace cungLaoDong.Models;

[Table(name: "cung_nguoilaodong")]
public class EmployeeFormModel
{
    [Key] [Column("nld_id")] public int Id { get; set; }

    [Required(ErrorMessage = "Họ và tên không được trống")]
    [StringLength(255, ErrorMessage = "Họ và tên không được quá 255 ký tự")]
    [DisplayName("Họ và tên")]
    [Column("nld_ten")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "CCCD không được trống")]
    [StringLength(12, ErrorMessage = "CCCD không được quá 12 ký tự")]
    [DisplayName("CCCD")]
    [Column("nld_cccd")]
    public string? Identity { get; set; }

    [Required(ErrorMessage = "Ngày sinh không được trống")]
    [DisplayName("Ngày sinh")]
    [Column("nld_ngay_sinh")]
    public DateTime? Birthday { get; set; }

    [Required(ErrorMessage = "Giới tính không được trống")]
    [DisplayName("Giới tính")]
    [Column("nld_gioi_tinh")]
    public bool Gender { get; set; }

    [Required(ErrorMessage = "Tỉnh thường trú không được trống")]
    [DisplayName("Tỉnh thường trú")]
    [Column("nld_thuong_tru_tinh_id")]
    public string? PermanentProvince { get; set; }

    [Required(ErrorMessage = "Phường / xã thường trú không được trống")]
    [DisplayName("Phường / xã thường trú")]
    [Column("nld_thuong_tru_phuongxa_id")]
    public string? PermanentWard { get; set; }

    [Required(ErrorMessage = "Địa chỉ thường trú không được trống")]
    [DisplayName("Địa chỉ thường trú")]
    [Column("nld_thuong_tru_diachichitiet")]
    public string? PermanentAddress { get; set; }

    [DisplayName("Tỉnh hiện tại")] 
    [Column("nld_tam_tru_tinh_id")]
    public string? TemporaryResidenceProvince { get; set; }

    [DisplayName("Phường / xã hiện tại")] 
    [Column("nld_tam_tru_phuongxa_id")]
    public string? TemporaryResidenceWard { get; set; }

    [DisplayName("Địa chỉ hiện tại")] 
    [Column("nld_tam_tru_diachichitiet")]
    public string? TemporaryResidenceAddress { get; set; }

    [DisplayName("Tình trạng kinh tế")] 
    [Column("ttkt_loai")]
    public int EconomyStatus { get; set; }

    [DisplayName("Lý do không tham gia hoạt động kinh tế")]
    [Column("ldktg_loai")]
    public int? UnemployedReason { get; set; }
}