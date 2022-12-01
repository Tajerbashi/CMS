using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Error")]
        [Display(Name="Name : ")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Family Error")]
        [Display(Name = "Family : ")]
        public String Family { get; set; }

        [Required(ErrorMessage = "Age Error")]
        [Display(Name = "Age")]
        public byte Age { get; set; }

        [Display(Name = "Active : ")]
        public bool IsActive { get; set; }

    }
}