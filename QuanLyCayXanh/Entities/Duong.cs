using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class Duong
    {
        public Duong()
        {
            ViTris = new HashSet<ViTri>();
        }

        public string MaDuong { get; set; }
        public string TenDuong { get; set; }
        public string MaPhuong { get; set; }

        public virtual Phuong MaPhuongNavigation { get; set; }
        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}
