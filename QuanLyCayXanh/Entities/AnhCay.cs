using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class AnhCay
    {
        public string MaAnhCay { get; set; }
        public string HinhAnh { get; set; }
        public string MaCay { get; set; }

        public virtual CayXanh MaCayNavigation { get; set; }
    }
}
