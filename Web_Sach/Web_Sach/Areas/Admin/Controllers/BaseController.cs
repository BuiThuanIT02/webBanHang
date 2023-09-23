using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web_Sach.Session;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLoginSession)Session[SessionHelper.USER_KEY];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(

                  new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string content, string message)
        {
            TempData["AlertContent"] = content;

            if(message == "success")
            {
                TempData["AlertMessage"] = "alert-success";
            }
            else if( message == "warning")
            {
                TempData["AlertMessage"] = "alert-warning";
            }
            else if(message == "error")
            {
                TempData["AlertMessage"] = "alert-danger";
            }

        }












    }
}