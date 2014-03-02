using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Models;

namespace AcmeKata.WebUI.Controllers
{
    public class AdController : Controller
    {
        public ActionResult Index(int id)
        {
            TempData["paperId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult GetAdText(string adText)
        {
            TempData["adText"] = adText;
            
            return RedirectToAction("PlaceAd", "Home");
        }
    }
}
