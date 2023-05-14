using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class LoaiCay
    {
        public LoaiCay()
        {
            CayXanhs = new HashSet<CayXanh>();
        }

        public string MaLoaiCay { get; set; }
        public string TenLoaiCay { get; set; }
        public string LoaiRe { get; set; }
        public string LoaiThan { get; set; }
        public string LoaiLa { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<CayXanh> CayXanhs { get; set; }
    }
}
