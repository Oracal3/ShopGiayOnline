namespace DullStore.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DullStoreDbContex : DbContext
    {
        public DullStoreDbContex()
            : base("name=DullStoreDbContex")
        {
        }

        public virtual DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Style> Style { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.dongia)
                .IsFixedLength();

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.tendanhmuc)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.SanPham)
                .WithOptional(e => e.DanhMuc)
                .HasForeignKey(e => e.madanhmuc);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHang)
                .WithRequired(e => e.GioHang)
                .HasForeignKey(e => e.magiohang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHang)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.makhachhang);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHang)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.magiay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Style>()
                .HasMany(e => e.SanPham)
                .WithOptional(e => e.Style)
                .HasForeignKey(e => e.mastyle);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
