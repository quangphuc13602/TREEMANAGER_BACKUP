using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCayXanh.Entities
{
    public partial class Quan
    {
        public Quan()
        {
            Phuongs = new HashSet<Phuong>();
        }

        public string MaQuan { get; set; }
        public string TenQuan { get; set; }

        public virtual ICollection<Phuong> Phuongs { get; set; }
    }
}
