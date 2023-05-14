using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class QLCayxanhContext : DbContext
    {
        public QLCayxanhContext()
        {
        }

        public QLCayxanhContext(DbContextOptions<QLCayxanhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhCay> AnhCays { get; set; }
        public virtual DbSet<CayXanh> CayXanhs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<DanhGium> DanhGia { get; set; }
        public virtual DbSet<Duong> Duongs { get; set; }
        public virtual DbSet<LoaiCay> LoaiCays { get; set; }
        public virtual DbSet<LoaiCongViec> LoaiCongViecs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phuong> Phuongs { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<ViTri> ViTris { get; set; }
        public virtual DbSet<XacNhan> XacNhans { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebQuanLyCayXanh;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnhCay>(entity =>
            {
                entity.HasKey(e => e.MaAnhCay)
                    .HasName("PK__anhCay__DC6540E224F42B26");

                entity.ToTable("anhCay");

                entity.Property(e => e.MaAnhCay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maAnhCay");

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("hinhAnh");

                entity.Property(e => e.MaCay)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maCay");

                entity.HasOne(d => d.MaCayNavigation)
                    .WithMany(p => p.AnhCays)
                    .HasForeignKey(d => d.MaCay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anhCay__maCay__46E78A0C");
            });

            modelBuilder.Entity<CayXanh>(entity =>
            {
                entity.HasKey(e => e.MaCay)
                    .HasName("PK__cayXanh__2C8F2FFFFD76752D");

                entity.ToTable("cayXanh");

                entity.Property(e => e.MaCay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maCay");

                entity.Property(e => e.LoaiCay)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("loaiCay");

                entity.Property(e => e.MoTaCay)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("moTaCay");

                entity.Property(e => e.TenCay)
                    .HasMaxLength(225)
                    .HasColumnName("tenCay");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(100)
                    .HasColumnName("trangThai");

                entity.Property(e => e.Tuoi).HasColumnName("tuoi");

                entity.Property(e => e.ViTri)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("viTri");

                entity.HasOne(d => d.LoaiCayNavigation)
                    .WithMany(p => p.CayXanhs)
                    .HasForeignKey(d => d.LoaiCay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cayXanh__loaiCay__440B1D61");

                entity.HasOne(d => d.ViTriNavigation)
                    .WithMany(p => p.CayXanhs)
                    .HasForeignKey(d => d.ViTri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cayXanh__viTri__4316F928");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu)
                    .HasName("PK__chucVu__6E42BCD9165BF1A5");

                entity.ToTable("chucVu");

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maChucVu");

                entity.Property(e => e.TenChucVu)
                    .HasMaxLength(225)
                    .HasColumnName("tenChucVu");
            });

            modelBuilder.Entity<CongViec>(entity =>
            {
                entity.HasKey(e => e.MaCongViec)
                    .HasName("PK__congViec__CDBE9810656DE8D6");

                entity.ToTable("congViec");

                entity.Property(e => e.MaCongViec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maCongViec");

                entity.Property(e => e.MaCay)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maCay");

                entity.Property(e => e.MaLoaiCv)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maLoaiCV");

                entity.Property(e => e.MoTa)
                    .HasMaxLength(255)
                    .HasColumnName("moTa");

                entity.Property(e => e.NgayBatDau)
                    .HasColumnType("date")
                    .HasColumnName("ngayBatDau");

                entity.Property(e => e.NgayKetThuc)
                    .HasColumnType("date")
                    .HasColumnName("ngayKetThuc");

                entity.Property(e => e.NhanVien)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("nhanVien")
                    .IsFixedLength(true);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("trangThai");

                entity.HasOne(d => d.MaCayNavigation)
                    .WithMany(p => p.CongViecs)
                    .HasForeignKey(d => d.MaCay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__congViec__maCay__571DF1D5");

                entity.HasOne(d => d.MaLoaiCvNavigation)
                    .WithMany(p => p.CongViecs)
                    .HasForeignKey(d => d.MaLoaiCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__congViec__maLoai__5535A963");

                entity.HasOne(d => d.NhanVienNavigation)
                    .WithMany(p => p.CongViecs)
                    .HasForeignKey(d => d.NhanVien)
                    .HasConstraintName("FK__congViec__nhanVi__5812160E");

                entity.HasOne(d => d.TrangThaiNavigation)
                    .WithMany(p => p.CongViecs)
                    .HasForeignKey(d => d.TrangThai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__congViec__trangT__5629CD9C");
            });

            modelBuilder.Entity<DanhGium>(entity =>
            {
                entity.HasKey(e => e.MaDanhGia)
                    .HasName("PK__danhGia__6B15DD9A18C48825");

                entity.ToTable("danhGia");

                entity.Property(e => e.MaDanhGia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maDanhGia");

                entity.Property(e => e.NhanVien)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("nhanVien")
                    .IsFixedLength(true);

                entity.Property(e => e.NoiDung)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("noiDung");

                entity.HasOne(d => d.NhanVienNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.NhanVien)
                    .HasConstraintName("FK__danhGia__nhanVie__52593CB8");
            });

            modelBuilder.Entity<Duong>(entity =>
            {
                entity.HasKey(e => e.MaDuong)
                    .HasName("PK__Duong__89A7AB00EAE6B0AD");

                entity.ToTable("Duong");

                entity.Property(e => e.MaDuong)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maDuong");

                entity.Property(e => e.MaPhuong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maPhuong");

                entity.Property(e => e.TenDuong)
                    .HasMaxLength(100)
                    .HasColumnName("tenDuong");

                entity.HasOne(d => d.MaPhuongNavigation)
                    .WithMany(p => p.Duongs)
                    .HasForeignKey(d => d.MaPhuong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Duong__maPhuong__3D5E1FD2");
            });

            modelBuilder.Entity<LoaiCay>(entity =>
            {
                entity.HasKey(e => e.MaLoaiCay)
                    .HasName("PK__loaiCay__331F9F2999F78985");

                entity.ToTable("loaiCay");

                entity.Property(e => e.MaLoaiCay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maLoaiCay");

                entity.Property(e => e.LoaiLa)
                    .HasMaxLength(100)
                    .HasColumnName("loaiLa");

                entity.Property(e => e.LoaiRe)
                    .HasMaxLength(100)
                    .HasColumnName("loaiRe");

                entity.Property(e => e.LoaiThan)
                    .HasMaxLength(100)
                    .HasColumnName("loaiThan");

                entity.Property(e => e.MoTa)
                    .HasMaxLength(500)
                    .HasColumnName("moTa");

                entity.Property(e => e.TenLoaiCay)
                    .HasMaxLength(100)
                    .HasColumnName("tenLoaiCay");
            });

            modelBuilder.Entity<LoaiCongViec>(entity =>
            {
                entity.HasKey(e => e.MaLoaiCongViec)
                    .HasName("PK__loaiCong__340B10DEF19EF947");

                entity.ToTable("loaiCongViec");

                entity.Property(e => e.MaLoaiCongViec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maLoaiCongViec");

                entity.Property(e => e.TenCongViec)
                    .HasMaxLength(225)
                    .HasColumnName("tenCongViec");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Cmnd)
                    .HasName("PK__nhanVien__F67C8D0A3EDA25D7");

                entity.ToTable("nhanVien");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .HasColumnName("diaChi");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(3)
                    .HasColumnName("gioiTinh");

                entity.Property(e => e.MaChucVu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maChucVu");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaySinh");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength(true);

                entity.Property(e => e.TenNhanVien)
                    .HasMaxLength(225)
                    .HasColumnName("tenNhanVien");

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaChucVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nhanVien__maChuc__4F7CD00D");
            });

            modelBuilder.Entity<Phuong>(entity =>
            {
                entity.HasKey(e => e.MaPhuong)
                    .HasName("PK__Phuong__DF98DF67A86B2C87");

                entity.ToTable("Phuong");

                entity.Property(e => e.MaPhuong)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maPhuong");

                entity.Property(e => e.MaQuan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maQuan");

                entity.Property(e => e.TenPhuong)
                    .HasMaxLength(100)
                    .HasColumnName("tenPhuong");

                entity.HasOne(d => d.MaQuanNavigation)
                    .WithMany(p => p.Phuongs)
                    .HasForeignKey(d => d.MaQuan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Phuong__maQuan__3A81B327");
            });

            modelBuilder.Entity<Quan>(entity =>
            {
                entity.HasKey(e => e.MaQuan)
                    .HasName("PK__Quan__D8C7F6091BD69418");

                entity.ToTable("Quan");

                entity.Property(e => e.MaQuan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maQuan");

                entity.Property(e => e.TenQuan)
                    .HasMaxLength(100)
                    .HasColumnName("tenQuan");
            });

            modelBuilder.Entity<ViTri>(entity =>
            {
                entity.HasKey(e => e.MaToaDo)
                    .HasName("PK__viTri__EB6535C0CE5AFB81");

                entity.ToTable("viTri");

                entity.Property(e => e.MaToaDo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("maToaDo");

                entity.Property(e => e.MaDuong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maDuong");

                entity.HasOne(d => d.MaDuongNavigation)
                    .WithMany(p => p.ViTris)
                    .HasForeignKey(d => d.MaDuong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__viTri__maDuong__403A8C7D");
            });

            modelBuilder.Entity<XacNhan>(entity =>
            {
                entity.HasKey(e => e.MaXacNhan)
                    .HasName("PK__xacNhan__EDFABF10EA5FEDE0");

                entity.ToTable("xacNhan");

                entity.Property(e => e.MaXacNhan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maXacNhan");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(225)
                    .HasColumnName("trangThai");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
