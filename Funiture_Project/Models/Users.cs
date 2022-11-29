using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Funiture_Project.Models
{
    public partial class Users
    {
        public int MaUser { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string ThanhPho { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? Quyen { get; set; }
        public string GioiTinh { get; set; }
    }
}
