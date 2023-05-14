using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class CayXanh
    {
        public CayXanh()
        {
            AnhCays = new HashSet<AnhCay>();
            CongViecs = new HashSet<CongViec>();
        }

        public string MaCay { get; set; }
        public string TenCay { get; set; }
        public int? Tuoi { get; set; }
        public string MoTaCay { get; set; }
        public string ViTri { get; set; }
        public string LoaiCay { get; set; }
        public string TrangThai { get; set; }

        public virtual LoaiCay LoaiCayNavigation { get; set; }
        public virtual ViTri ViTriNavigation { get; set; }
        public virtual ICollection<AnhCay> AnhCays { get; set; }
        public virtual ICollection<CongViec> CongViecs { get; set; }
    }
}
