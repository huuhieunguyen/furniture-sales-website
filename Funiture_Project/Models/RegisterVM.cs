using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Funiture_Project.Models
{
    public class RegisterVM
    {
        [Key]
        [Required]
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }
        [Required]
        public string GioiTinh { get; set; }
        [Required]
        public string DiaChi { get; set;}
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
