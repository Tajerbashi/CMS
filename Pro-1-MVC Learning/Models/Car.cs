using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Models
{
    public class Car
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Name is not valid!")]
        [Display(Name ="Name : ")]
        [Remote("CheckName", "ValidationNext",ErrorMessage ="Name is Exist")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Model is not valid!")]
        [Display(Name = "Model : ")]
        public string Model  { get; set; }

        [Required(ErrorMessage ="Email is not valid!")]
        [EmailAddress(ErrorMessage ="Email Type Is Not Email Format!!!")]
        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Empty !!!")]
        [Display(Name = "Password : ")]
        public string Pass { get; set; }

        [Display(Name = "Re-Password : ")]
        [Required(ErrorMessage = "Re_Password is Empty !!!")]
        public string RePass { get; set; }

    }
}