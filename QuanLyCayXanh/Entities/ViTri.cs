using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class ViTri
    {
        public ViTri()
        {
            CayXanhs = new HashSet<CayXanh>();
        }

        public string MaToaDo { get; set; }
        public string MaDuong { get; set; }

        public virtual Duong MaDuongNavigation { get; set; }
        public virtual ICollection<CayXanh> CayXanhs { get; set; }
    }
}
