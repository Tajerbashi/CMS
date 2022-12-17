using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminLogin
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage ="You Must Fill Input")]
        [Display(Name ="Username")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "Email")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "Password")]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
