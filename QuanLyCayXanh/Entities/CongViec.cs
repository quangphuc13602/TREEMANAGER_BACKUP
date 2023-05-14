using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class CongViec
    {
        public string MaCongViec { get; set; }
        public string MaLoaiCv { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public string MaCay { get; set; }
        public string NhanVien { get; set; }

        public virtual CayXanh MaCayNavigation { get; set; }
        public virtual LoaiCongViec MaLoaiCvNavigation { get; set; }
        public virtual NhanVien NhanVienNavigation { get; set; }
        public virtual XacNhan TrangThaiNavigation { get; set; }
    }
}
