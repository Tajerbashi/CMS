using FluentMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class Teacher : FluentMvc.IModelInitializer<Teacher>
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String RePass { get; set; }

        public void InitializeModel(ModelContext<Teacher> context)
        {
            context.TemplatesFor(c => c.UserName).Display("Username");
            context.RulesFor(reg => reg.UserName)
                .Required(c => c.Message("Username is Empty !!!"))
                .Remote<Controllers.ValidationNextController>(c => c.CheckUser, "Username is Exist !");
            context.RulesFor(reg => reg.Password)
                .Required(c => c.Message("Password is Empty"))
                .CustomValidator(pass => pass.Password.Equals(RePass), (msg => msg.Message("Pass is not coorect")
                .When(model => string.IsNullOrEmpty(model.Password))
                .StopOnFail()));
        }
    }
}