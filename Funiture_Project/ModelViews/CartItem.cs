using Funiture_Project.Models;
namespace Funiture_Project.ModelViews
{
    public class CartItem
    {
        public SanPham sanPham { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * sanPham.Gia;
    }
}
