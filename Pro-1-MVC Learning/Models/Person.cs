using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace Pro_1_MVC_Learning.Models
{
    public class Person: IValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Error")]
        [Display(Name="Name : ")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Family Error")]
        [Display(Name = "Family : ")]
        public String Family { get; set; }

        [Required(ErrorMessage = "Age Error")]
        [Display(Name = "Age : ")]
        public byte Age { get; set; }

        [Display(Name = "Active : ")]
        public bool IsActive { get; set; }

        public bool Validate(System.Web.Mvc.ModelStateDictionary modelState)
        {
            if (!string.IsNullOrEmpty(Name) && Name.Equals(Family))
            {
                modelState.AddModelError("Name","This is a test Error message");
            }
            return true;
        }
    }
}