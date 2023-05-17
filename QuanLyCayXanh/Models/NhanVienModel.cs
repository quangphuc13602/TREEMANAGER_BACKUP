using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Models
{
    public class NhanVienModel
    {
        public string Cmnd { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string TenChucVu { get; set; }
    }
    public class NhanVVienCongViec
    {
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string tenCongViec { get; set; }
        public string mota { get; set; }
        public string TenCay { get; set; }
        public string Vitri { get; set; }
        public string Duong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThaiCV { get; set; }
    }
}
