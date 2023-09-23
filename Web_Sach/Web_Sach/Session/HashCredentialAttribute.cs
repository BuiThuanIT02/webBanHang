using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Sach.Session
{
    public class HashCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;
            //}
            var session = (UserLoginSession)HttpContext.Current.Session[SessionHelper.USER_KEY];
            if(session == null)
            {
                return false;
            }
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserName); // danh sách quyền role
            if (privilegeLevels.Contains(this.RoleID) || session.GroupID=="ADMIN")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error_401.cshtml"
            };
        }

            private List<String> GetCredentialByLoggedInUser(string userName)
            {
               var credentials = (List<string>)HttpContext.Current.Session[SessionHelper.SESSION_CREDENTIALS];

                    return credentials;
            }


        
    }
}