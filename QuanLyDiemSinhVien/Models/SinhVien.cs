

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDiemSinhVien.Models
{
    [Table("SinhViens")]
    public class SinhVien
    {
        [Key]
        [DisplayName("Mã sinh viên")]
        public string MaSV { get; set; }
        [Required, DisplayName("Tên sinh viên")]
        public string TenSV { get; set; }
        [Required, DisplayName("Giới tính")]
        public string GioiTinh { get; set; }
        [Required, DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required, DisplayName("Mã lớp")]
        public string MaLop { get; set; }
        [Required, DisplayName("Quê quán")]
        public string QueQuan { get; set; }
        public ICollection<Diem> Diems { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lops { get; set; }
    }
}