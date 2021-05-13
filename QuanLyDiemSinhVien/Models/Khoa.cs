
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace QuanLyDiemSinhVien.Models
{
    [Table("Khoas")]
    public class Khoa
    {
        [Key]
        [DisplayName("Mã khoa")]
        public string MaKhoa { get; set; }
        [Required, DisplayName("Tên khoa")]
       
        public string TenKhoa { get; set; }
        [Required, DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [Required, DisplayName("Điện thoại")]
        public string DienThoai { get; set; }
        [AllowHtml]
        public string Logo{ get; set; }
        public ICollection<Lop> Lops { get; set; }
    }
}