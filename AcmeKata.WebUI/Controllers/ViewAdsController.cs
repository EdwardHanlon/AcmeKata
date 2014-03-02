using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeKata.Entities.Interfaces;

namespace AcmeKata.WebUI.Controllers
{
    public class ViewAdsController : Controller
    {
        private IDataReader reader;

        public ViewAdsController(IDataReader _reader)
        {
            reader = _reader;
        }

        public ActionResult Index(int id)
        {
            return View(reader.GetAllAdsForPaper(id));
        }
    }
}
