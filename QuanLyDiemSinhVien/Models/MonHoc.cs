
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDiemSinhVien.Models
{
    [Table("MonHocs")]
    public class MonHoc
    {
        [Key]
        [DisplayName("Mã môn học")]
        public string MaMH { get; set; }
        [Required, DisplayName("Tên môn học")]
        public string TenMH { get; set; }
        [Required, DisplayName("Số tín chỉ")]
        public int SoTinChi { get; set; }
        public ICollection<Diem> Diems { get; set; }
    }
}