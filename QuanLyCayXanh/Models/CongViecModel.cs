using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Models
{
    public class CongViecModel
    {
        public string MaCongViec { get; set; }
        public string MaLoaiCv { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public string MaCay { get; set; }
        public string NhanVien { get; set; }
    }
    public class LoaiCongViecModel
    {
        public string MaLoaiCongViec { get; set; }
        public string TenLoaiCongVIec { get; set; }
    }
}
