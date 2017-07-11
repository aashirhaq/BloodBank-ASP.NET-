using BloodBank.Models;
using BloodBank.ViewModel.DonorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DonorDataViewModel ddvm = new DonorDataViewModel();
            List<DonorData> dd = ddvm.GetAllData();
            return View(dd);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DonorData dd)
        {

            if (ModelState.IsValid)
            {
                DonorDataViewModel ddvm = new DonorDataViewModel();
                ddvm.AddNewRecord(dd);

                return RedirectToAction("Index");
            }
            return View();
        
        }
    }
}