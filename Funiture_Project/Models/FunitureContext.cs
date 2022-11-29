using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Funiture_Project.Models
{
    public partial class FunitureContext : DbContext
    {
        public FunitureContext()
        {
        }

        public FunitureContext(DbContextOptions<FunitureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cthd> Cthd { get; set; }
        public virtual DbSet<DanhMucSp> DanhMucSp { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HIEUHP; Database=Funiture; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("pk_CTHD");

                entity.ToTable("CTHD");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");
            });

            modelBuilder.Entity<DanhMucSp>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("pk_DanhMucSP");

                entity.ToTable("DanhMucSP");

                entity.Property(e => e.MaDm)
                    .HasColumnName("MaDM")
                    .HasMaxLength(255);

                entity.Property(e => e.TenDm)
                    .HasColumnName("TenDM")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => new { e.MaUser, e.MaSp });

                entity.Property(e => e.MaSp).HasColumnName("MaSP");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaKm).HasColumnName("MaKM");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayGh)
                    .HasColumnName("NgayGH")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayHd)
                    .HasColumnName("NgayHD")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThanhPho).HasMaxLength(255);

                entity.Property(e => e.Ttdh)
                    .HasColumnName("TTDH")
                    .HasMaxLength(255);

                entity.Property(e => e.Tttt)
                    .HasColumnName("TTTT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm);

                entity.Property(e => e.MaKm)
                    .HasColumnName("MaKM")
                    .ValueGeneratedNever();

                entity.Property(e => e.NgayBd)
                    .HasColumnName("NgayBD")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayKt)
                    .HasColumnName("NgayKT")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhanTramKm).HasColumnName("PhanTramKM");

                entity.Property(e => e.TenKm)
                    .HasColumnName("TenKM")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .ValueGeneratedNever();

                entity.Property(e => e.HinhAnh).HasMaxLength(255);

                entity.Property(e => e.MaDm)
                    .HasColumnName("MaDM")
                    .HasMaxLength(255);

                entity.Property(e => e.Nsx)
                    .HasColumnName("NSX")
                    .HasMaxLength(255);

                entity.Property(e => e.TenSp)
                    .HasColumnName("TenSP")
                    .HasMaxLength(255);

                entity.Property(e => e.ThuongHieu).HasMaxLength(255);

                entity.Property(e => e.TongSl).HasColumnName("TongSL");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.MaUser);

                entity.Property(e => e.MaUser).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(255);

                entity.Property(e => e.ThanhPho).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
