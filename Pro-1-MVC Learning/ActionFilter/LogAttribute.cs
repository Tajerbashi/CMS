using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.ActionFilter
{
    public class LogAttribute:ActionFilterAttribute
    {
        public static List<string> _logs=new List<string>();
        //  Before Request to my action
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller= filterContext.RouteData.Values["controller"].ToString();
            var action= filterContext.RouteData.Values["action"].ToString();
            _logs.Add(string.Format("Action {0} on Controller {1} Executing",action,controller));
            base.OnActionExecuting(filterContext);
        }
        //  After Request to my action
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            if (filterContext.Exception != null)
            {
                _logs.Add(string.Format("Exeception on Action {0}, Controller {1} {2}", action, controller, filterContext.Exception.Message));
            }
            _logs.Add(string.Format("Action {0} on Controller {1} Executing", action, controller));
            filterContext.Controller.ViewBag.Message = "This is a message for all of View";
            base.OnActionExecuted(filterContext);
        }
    }
}