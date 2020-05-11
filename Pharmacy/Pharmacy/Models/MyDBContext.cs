namespace Pharmacy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext1")
        {
        }

        public virtual DbSet<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }
        public virtual DbSet<HANGSANXUAT> HANGSANXUATs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAITHUOC> LOAITHUOCs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUATs { get; set; }
        public virtual DbSet<THUOC> THUOCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MaPhieuXuat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETPHIEUXUAT>()
                .Property(e => e.MaThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGSANXUAT>()
                .Property(e => e.MaHangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CMND_TCCCD)
                .IsFixedLength();

            modelBuilder.Entity<LOAITHUOC>()
                .Property(e => e.MaLoaiThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAITHUOC>()
                .HasMany(e => e.THUOCs)
                .WithRequired(e => e.LOAITHUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNhaCungCap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MaPhieuXuat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.PHIEUXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaLoaiThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaHangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaNhaCungCap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.CHITIETPHIEUXUATs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);
        }
    }
}
