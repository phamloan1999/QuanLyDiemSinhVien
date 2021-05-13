

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDiemSinhVien.Models
{
    [Table("Diems")]
    public class Diem
    {
        [Key]
        [DisplayName("Học kỳ")]
        public int HocKy { get; set; }
        [Required, DisplayName("Mã sinh viên")]
        public string MaSV { get; set; }
        [Required, DisplayName("Mã môn học")]
        public string MaMH { get; set; }
        [Required, DisplayName("Điểm lần 1")]
        public float DiemLan1 { get; set; }
        [Required, DisplayName("Điểm lần 2")]
        public float DiemLan2 { get; set; }
        [Required, DisplayName("Điểm trung bình")]
        public float DiemTrungBinh { get; set; }
        [Required, DisplayName("Xếp loại")]
        public string XepLoai { get; set; }

        [ForeignKey("MaMH")]
        public MonHoc MonHocs { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhViens { get; set; }
    }
}



    
