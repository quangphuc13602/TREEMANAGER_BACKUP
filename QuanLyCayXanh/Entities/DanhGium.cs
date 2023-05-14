using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class DanhGium
    {
        public string MaDanhGia { get; set; }
        public string NoiDung { get; set; }
        public string NhanVien { get; set; }

        public virtual NhanVien NhanVienNavigation { get; set; }
    }
}
