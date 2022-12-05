using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Funiture_Project.DataDB
{
    public partial class SanPham
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string Nsx { get; set; }
        public string ThuongHieu { get; set; }
        public double Gia { get; set; }
        public int TongSl { get; set; }
        public string HinhAnh { get; set; }
        public string MaDm { get; set; }
        public string ChiTiet { get; set; }
    }
}
