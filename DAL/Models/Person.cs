using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام فامیلی را وارد کنید!")]
        public string Family { get; set; }

        [Required(ErrorMessage = "شماره تلفن را وارد کنید!")]
        [Remote("CheckValidation", "Home", ErrorMessage = "شماره تلفن موجود است")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید!")]
        [EmailAddress(ErrorMessage ="ایمیل درست نیست")]
        [Remote("CheckValidation", "Home", ErrorMessage = "ایمیل موجود است")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری را وارد کنید!")]
        [Remote("CheckValidation", "Home", ErrorMessage = "نام کاربری موجود است")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز را وارد کنید!")]
        [Remote("CheckValidation", "Home", ErrorMessage = "پسورد همخوانی ندارد!")]
        public string PasswordSlat { get; set; }

        public string Photo { get; set; }

    }
}
