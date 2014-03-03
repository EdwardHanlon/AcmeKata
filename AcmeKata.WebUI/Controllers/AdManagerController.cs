using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeKata.Entities.Interfaces;

namespace AcmeKata.WebUI.Controllers
{
    public class AdManagerController : Controller
    {
        private IDataReader reader;

        public AdManagerController(IDataReader _reader)
        {
            reader = _reader;
        }

        public ActionResult ViewAllAds(int id)
        {
            return View(reader.GetAllAdsForNewspaperId(id));
        }
    }
}
