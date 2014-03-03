using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Models;

namespace AcmeKata.WebUI.Controllers
{
    public class NewAdController : Controller
    {
        public ActionResult NewAd(int id)
        {
            TempData["newspaperId"] = id;
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
