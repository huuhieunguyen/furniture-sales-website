using System;
using System.Collections.Generic;

namespace Funiture_Project.Models
{
    public class DSSanPham
    {
        private int mahd;
        private int masp;
        private int soluong;
        private double dongia;
        private string tensp;
        private string hinhanh;
        private string nsx;
        public DSSanPham(int mahd, int masp, int soluong, double dongia, string tensp, string hinhanh, string nsx)
        {
            this.mahd = mahd;
            this.masp = masp;
            this.soluong = soluong;
            this.dongia = dongia;
            this.tensp = tensp;
            this.hinhanh = hinhanh;
            this.nsx = nsx;
        }
        public int MaHD
        {
            get { return mahd; }
            set { mahd = value; }
        }
        public int MaSP
        {
            get { return masp; }
            set { masp = value; }
        }
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public double DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        public string TenSP
        {
            get { return tensp; }
            set { tensp = value; }
        }
        public string HinhAnh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
        }
        public string NSX
        {
            get { return nsx; }
            set { nsx = value; }
        }
    }
}
