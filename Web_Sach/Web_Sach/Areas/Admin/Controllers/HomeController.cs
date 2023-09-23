using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Session;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var session = (UserLoginSession)Session[SessionHelper.USER_KEY];
           

            return View(session);
        }
    }
}