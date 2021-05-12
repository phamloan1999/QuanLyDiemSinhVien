

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDiemSinhVien.Models
{
    [Table("AccountModels")]

    public class AccountModel
    {
        [Key]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Pasword is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RoleID { get; set; }

    }
}