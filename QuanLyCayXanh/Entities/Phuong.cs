using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class Phuong
    {
        public Phuong()
        {
            Duongs = new HashSet<Duong>();
        }

        public string MaPhuong { get; set; }
        public string TenPhuong { get; set; }
        public string MaQuan { get; set; }

        public virtual Quan MaQuanNavigation { get; set; }
        public virtual ICollection<Duong> Duongs { get; set; }
    }
}
