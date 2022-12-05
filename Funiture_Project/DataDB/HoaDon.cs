using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Funiture_Project.DataDB
{
    public partial class HoaDon
    {
        public int MaHd { get; set; }
        public string Ttdh { get; set; }
        public string Tttt { get; set; }
        public int MaKh { get; set; }
        public int MaNv { get; set; }
        public DateTime NgayHd { get; set; }
        public DateTime NgayGh { get; set; }
        public string DiaChi { get; set; }
        public string ThanhPho { get; set; }
        public int? MaKm { get; set; }
        public double TriGia { get; set; }
    }
}
