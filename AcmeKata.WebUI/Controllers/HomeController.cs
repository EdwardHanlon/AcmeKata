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

        public ActionResult SavePapers(IEnumerable<Newspaper> newNewspapers)
        {
            writer.SaveNewNewspapers(newNewspapers);
            return RedirectToAction("Index");
        }
        
        public ActionResult PlaceAd()
        {
            var adToPlace = new Ad(TempData["adText"].ToString());
            var newPaper = newspapers.FirstOrDefault(x => x.Id == Convert.ToInt32(TempData["paperId"].ToString()));

            if (newPaper != null)
            {
                //Persist New Ad in Database
                newPaper.PlaceAd(adToPlace);
                writer.SaveNewAd(newPaper.Id, adToPlace);
            }

            return RedirectToAction("Index");
        }

        public ActionResult CreatePaper(DateTime? issueDate)
        {
            DateTime dateToUse = issueDate == null ? DateTime.Today.Date : (DateTime)issueDate;

            var newPaper = new Newspaper(dateToUse, reader.GetMaxId());
            newspapers.Add(newPaper);
            writer.SaveNewNewspaper(newPaper);
            return RedirectToAction("Index");
        }
    }
}
