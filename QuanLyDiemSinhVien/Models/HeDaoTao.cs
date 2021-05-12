
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDiemSinhVien.Models
{
    [Table("HeDaoTaos")]
    public class HeDaoTao
    {
        [Key]
        [DisplayName("Mã hệ đào tạo")]
        public string MaHeDaoTao { get; set; }
        [Required, DisplayName("Tên hệ đào tạo")]
        public string TenHeDaoTao { get; set; }
        public ICollection<Lop> Lops { get; set; }
    }
}