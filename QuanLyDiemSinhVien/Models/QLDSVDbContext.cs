using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDiemSinhVien.Models
{
    public partial class QLDSVDbContext : DbContext
    {
        public QLDSVDbContext()
            : base("name=QLDSVDbContext")
        {
        }

        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<HeDaoTao> HeDaoTaos { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs{ get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
       
        public virtual DbSet<AccountModel> AccountModels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diem>()
                .Property(e => e.HocKy);


            modelBuilder.Entity<HeDaoTao>()
                .Property(e => e.MaHeDaoTao)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.MaKhoaHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<MonHoc>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSV)
                .IsUnicode(false);



            modelBuilder.Entity<AccountModel>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
               .Property(e => e.RoleID)
               .IsUnicode(false);
        }
    }
}
