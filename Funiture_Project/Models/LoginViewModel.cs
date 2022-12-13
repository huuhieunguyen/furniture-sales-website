using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace Funiture_Project.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email_Phone { get; set; }

        [Required]
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}