using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDeveloper.ActionFilter
{
    public class LogActions : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            Log("OnActionExecuting", filterContext.RouteData);
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }


        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }
        

        private static void Log(string actionMethod, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = $"{actionMethod} controller:  { controllerName} action: { actionName}";
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Action Filter Log: " + message));            
            
        }
    }
}
