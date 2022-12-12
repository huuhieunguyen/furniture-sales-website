using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Funiture_Project.Models
{
    public partial class KhuyenMai
    {
        public int MaKm { get; set; }
        public string TenKm { get; set; }
        public DateTime NgayBd { get; set; }
        public DateTime NgayKt { get; set; }
        public double PhanTramKm { get; set; }
        public double DinhMuc { get; set; }
        public double? ToiDa { get; set; }
    }
}
