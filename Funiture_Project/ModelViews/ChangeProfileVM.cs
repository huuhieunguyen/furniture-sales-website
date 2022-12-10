using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Funiture_Project.ModelViews
{
    public class ChangeProfileVM
    {
        [Key]
        [Required] public string HoTen { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string SDT { get; set; }
        [Required] public string DiaChi { get; set; }
    }
}
