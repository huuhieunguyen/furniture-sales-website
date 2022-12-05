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
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
