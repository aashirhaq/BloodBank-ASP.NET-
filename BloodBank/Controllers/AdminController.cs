using BloodBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminPanel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminPanel(AdminPanel ap)
        {
            string u = ap.Username;
            string p = ap.Password;
            if (ModelState.IsValid)
            {
                using (BBDMSAdminEntities bb = new BBDMSAdminEntities())
                {
                    var log = bb.Admins.Where(a => a.Username.Equals(u) && a.Password.Equals(p)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["AdminUsername"] = log.Username;
                        return RedirectToAction("DataManagement", "DataManagement");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                }
            }
            return View();

        }
    }
}