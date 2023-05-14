using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class LoaiCongViec
    {
        public LoaiCongViec()
        {
            CongViecs = new HashSet<CongViec>();
        }

        public string MaLoaiCongViec { get; set; }
        public string TenCongViec { get; set; }

        public virtual ICollection<CongViec> CongViecs { get; set; }
    }
}
