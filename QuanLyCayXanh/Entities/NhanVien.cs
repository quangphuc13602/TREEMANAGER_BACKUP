using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            CongViecs = new HashSet<CongViec>();
            DanhGia = new HashSet<DanhGium>();
        }

        public string Cmnd { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string Password { get; set; }
        public string MaChucVu { get; set; }

        public virtual ChucVu MaChucVuNavigation { get; set; }
        public virtual ICollection<CongViec> CongViecs { get; set; }
        public virtual ICollection<DanhGium> DanhGia { get; set; }
    }
}
