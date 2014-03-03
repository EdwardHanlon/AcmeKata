using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Models;

namespace AcmeKata.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IDataReader reader;
        private IDataWriter writer;
        private List<Newspaper> newspapers; 
        
        public HomeController(IDataReader _reader, IDataWriter _writer)
        {
            reader = _reader;
            writer = _writer;
            newspapers = _reader.GetAllNewspapers().ToList();
        }

        public ActionResult Index()
        {
            return View(newspapers);
        }

        public ActionResult PlaceAd()
        {
            string adText = TempData["adText"].ToString();

            if (!string.IsNullOrEmpty(adText))
            {
                var adToPlace = new Ad(adText);
                var newspaperToGetNewAd = newspapers.FirstOrDefault(x => x.Id == Convert.ToInt32(TempData["newspaperId"].ToString()));

                if (newspaperToGetNewAd != null)
                {
                    //Persist New Ad in Database
                    newspaperToGetNewAd.PlaceAd(adToPlace);
                    writer.SaveNewAd(newspaperToGetNewAd.Id, adToPlace);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult CreateNewspaper(DateTime? issueDate)
        {
            DateTime dateToUse = issueDate == null ? DateTime.Today.Date : (DateTime)issueDate;

            var newPaper = new Newspaper(dateToUse, reader.GetMaxId());
            newspapers.Add(newPaper);
            writer.SaveNewNewspaper(newPaper);
            return RedirectToAction("Index");
        }
    }
}
