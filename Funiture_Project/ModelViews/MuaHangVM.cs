using System.ComponentModel.DataAnnotations;

namespace Funiture_Project.ModelViews
{
    public class MuaHangVM
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        public string FullName { get; set; }

        public string Email { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Địa chỉ nhận hàng")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Tỉnh/Thành")]
        public string TinhThanh { get; set; }

        public int PaymentID { get; set; }
        
        public string Note { get; set; }

        /*
        [Required(ErrorMessage = "Vui lòng chọn Quận/Huyện")]
        public int QuanHuyen { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Phường/Xã")]
        public int PhuongXa { get; set; }*/
    }
}
