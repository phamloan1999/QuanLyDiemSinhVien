
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDiemSinhVien.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}