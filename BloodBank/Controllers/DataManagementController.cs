using BloodBank.Models;
using BloodBank.ViewModel.DonorData;
using BloodBank.ViewModel.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class DataManagementController : Controller
    {
        // GET: DataManagement
        public ActionResult DataManagement()
        {
            return View();
        }

        public ActionResult DonorDataManagement()
        {
            DonorDataViewModel ddvm = new DonorDataViewModel();
            List<DonorData> dd = ddvm.GetAllData();
            return View(dd);
        }

        public ActionResult UserDetailManagement()
        {
            UserDetailViewModel ddvm = new UserDetailViewModel();
            List<UserData> ud = ddvm.GetAllData();
            return View(ud);
        }

        public ActionResult UpdateUserDetail(int Id)
        {
            UserDetailViewModel udvm = new UserDetailViewModel();
            UserData ud = udvm.GetUserDetail(Id);
            return View(ud);
        }
        [HttpPost]
        public ActionResult UpdateUserDetail(UserData userData)
        {
            if (ModelState.IsValid)
            {
                UserDetailViewModel udvm = new UserDetailViewModel();
                udvm.UpdateUserDetail(userData);
                return RedirectToAction("UserDetailManagement");
            }
            return View();
        }

        public ActionResult UpdateDonorData(int Id)
        {
            DonorDataViewModel ddvm = new DonorDataViewModel();
            DonorData dd = ddvm.GetDonorDataById(Id);
            return View(dd);
        }

        [HttpPost]
        public ActionResult UpdateDonorData(DonorData donorData)
        {
            if (ModelState.IsValid)
            {
                DonorDataViewModel ddvm = new DonorDataViewModel();
                ddvm.UpdateDonorData(donorData);
                return RedirectToAction("DonorDataManagement");
            }
            return View();
        }
    }
}