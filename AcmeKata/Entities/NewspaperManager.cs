using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Entities;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Models;

namespace AcmeKata.Helpers
{
    public class NewspaperManager
    {
        //public static Newspaper CollectNewspaperInfo(int nextIdAvailable)
        //{
        //    Console.WriteLine("Please enter an issue date for this Newspaper or press enter to use todays date");
            
        //    DateTime parsedDate;
        //    if (DateTime.TryParse(Console.ReadLine(), out parsedDate))
        //    {
        //        //Date parsed succesfully
        //    }
        //    else
        //    {
        //        parsedDate = DateTime.Today.Date;
        //    }

        //    var newsPaper = new Newspaper(parsedDate, nextIdAvailable);
        //    Console.WriteLine("Would you like to place an Ad in this paper? (Y/N)");
        //    string userInput = Console.ReadLine().ToUpper();

        //    while (userInput == "Y")
        //    {
        //        string adText = AdManager.GetTextForAd();
        //        newsPaper.PlaceAd(new Ad(adText));
        //        Console.WriteLine("Would you like to place another Ad? (Y/N)");
        //        userInput = Console.ReadLine().ToUpper();
        //    } 
            
        //    return newsPaper;
        //}
    }
}
