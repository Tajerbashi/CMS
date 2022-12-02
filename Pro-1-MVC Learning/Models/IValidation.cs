using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Models
{
    public interface IValidation
    {
        bool Validate(ModelStateDictionary modelState);
    }
}
