
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDiemSinhVien.Models
{
    [Table("Lops")]
    public class Lop
    {
        [Key]
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }
        [Required, DisplayName("Tên lớp")]
        public string TenLop { get; set; }
        [Required, DisplayName("Mã khoa")]
        public string MaKhoa { get; set; }
        [Required, DisplayName("Mã hệ đào tạo")]
        public string MaHeDaoTao { get; set; }
        [Required, DisplayName("Mã khóa học")]
        public string MaKhoaHoc { get; set; }
        [ForeignKey("MaKhoaHoc")]
        public KhoaHoc KhoaHocs { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa Khoas { get; set; }
        [ForeignKey("MaHeDaoTao")]
        public HeDaoTao HeDaoTaos { get; set; }
        public ICollection<SinhVien> SinhViens { get; set; }
    }
}