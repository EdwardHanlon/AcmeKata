using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Entities;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Helpers;
using AcmeKata.Models;
using AcmeKata.Modules;
using Ninject;

namespace AcmeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new AcmeModule());
            var reader = kernel.Get<IDataReader>();
            var writer = kernel.Get<IDataWriter>();
            
            var newspapers = reader.GetAllNewspapers().ToList();
            
            //Keep a seperate list to know which ones need to be saved on exit
            var newNewsPapers = new List<Newspaper>();

            bool userWantsToQuit = false;

            while (!userWantsToQuit) 
            {
                Console.WriteLine("******* Acme Newspaper Manager *******");
                ScreenHelpers.PrintOptions();

                Console.WriteLine("Please make a selection:");
                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        var newPaper = NewspaperManager.CollectNewspaperInfo(reader.GetMaxId());
                        newNewsPapers.Add(newPaper);
                        newspapers.Add(newPaper);
                    break;

                    case "2":
                        ScreenHelpers.PrintNewspapersList(newspapers);
                    break;

                    case "3":
                        ScreenHelpers.PrintNewspapersList(newspapers);
                        
                        Console.WriteLine("Please Enter the ID of the Newspaper to Add a new Ad to: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        
                        var selectedNewspaper = newspapers.FirstOrDefault(x => x.Id == id);
                        
                        if (selectedNewspaper != null)
                        {
                            string adText = AdManager.GetTextForAd();
                            selectedNewspaper.PlaceAd(new Ad(adText));
                        }
                        else
                        {
                            Console.WriteLine("That ID does not exist");
                        }

                    break;

                    case "Q":
                        writer.SaveNewNewspapers(newNewsPapers);
                        userWantsToQuit = true;
                    break;

                    default:
                        Console.WriteLine("That was not a valid selection, please try again");
                        Console.WriteLine();
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
