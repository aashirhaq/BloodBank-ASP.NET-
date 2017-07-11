using BloodBank.Models;
using BloodBank.ViewModel.RegisterUser;
using System.Linq;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(UserData ud)
        {
            string u = ud.Username;
            string p = ud.Password;
            if (ModelState.IsValid)
            {
                using (BBDMSEntities bb = new BBDMSEntities())
                {
                    var log = bb.Users.Where(a => a.Username.Equals(u) && a.Password.Equals(p)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["Username"] = log.Username;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                }

            }

            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(UserData ud)
        {
            if (ModelState.IsValid)
            {
                RegisterUserViewModel ddvm = new RegisterUserViewModel();
                ddvm.RegisterUser(ud);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}