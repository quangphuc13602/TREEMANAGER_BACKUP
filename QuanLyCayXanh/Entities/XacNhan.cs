using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class XacNhan
    {
        public XacNhan()
        {
            CongViecs = new HashSet<CongViec>();
        }

        public string MaXacNhan { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<CongViec> CongViecs { get; set; }
    }
}
