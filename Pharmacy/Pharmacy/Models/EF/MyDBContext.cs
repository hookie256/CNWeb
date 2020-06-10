namespace Pharmacy.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
        public virtual DbSet<HANGSANXUAT> HANGSANXUATs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAITHUOC> LOAITHUOCs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<THUOC> THUOCs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.MaThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MaThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIOHANG>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGSANXUAT>()
                .Property(e => e.MaHangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAITHUOC>()
                .Property(e => e.MaLoaiThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAITHUOC>()
                .Property(e => e.ParentID)
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
                .Property(e => e.UrlImage)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.Tien)
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .Property(e => e.TimKiem)
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.THUOC)
                .HasForeignKey(e => e.MaThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.CHITIETHOADONs1)
                .WithRequired(e => e.THUOC1)
                .HasForeignKey(e => e.MaThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.MaKM)
                .IsFixedLength();
        }
    }
}
