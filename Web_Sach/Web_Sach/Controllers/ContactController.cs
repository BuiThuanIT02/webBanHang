using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;

namespace Web_Sach.Controllers
{
    public class ContactController : Controller
    {  WebSachDb db = new WebSachDb();
        // GET: Contact
        public ActionResult Index()
        {
          
            var queryContact = from c in db.Contacts
                          where c.Status == true
                          select c;

            var modelContact = queryContact.FirstOrDefault();

            return View(modelContact);
        }


        [HttpPost]
        public JsonResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new FeedBack();
            feedback.Name = name;
            feedback.Email = email;
            feedback.CreatedDate = DateTime.Now;
            feedback.Phone = mobile;
            feedback.Content = content;
            feedback.Address = address;
            db.FeedBacks.Add(feedback);
            db.SaveChanges();
            var id = feedback.ID;

            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false

                });
            }

        }




    }
}