
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDiemSinhVien.Models
{
    [Table("KhoaHocs")]
    public class KhoaHoc
    {
        [Key]
        [DisplayName("Mã khóa học")]
        public string MaKhoaHoc { get; set; }
        [Required, DisplayName("Tên khóa học")]
        public string TenKhoaHoc { get; set; }
        public ICollection<Lop> Lops { get; set; }
    }
}