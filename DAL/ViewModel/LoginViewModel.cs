using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "Username")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "Password")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me!")]
        public bool IsRemember { get; set; }
    }
}
