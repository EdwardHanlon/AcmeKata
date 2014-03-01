using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Models;

namespace AcmeKata.Helpers
{
    class ScreenHelpers
    {
        public static void PrintOptions()
        {
            Console.WriteLine("[1] -- Press 1 to Create a new Newspaper");
            Console.WriteLine("[2] -- Press 2 to View all current Newspapers");
            Console.WriteLine("[3] -- Press 3 to Place an Ad in an existing Newspaper");
            Console.WriteLine("[Q] -- Press Q to Save all Newspapers and Quit the Program");
        }

        public static void PrintNewspapersList(List<Newspaper> newspapers)
        {
            foreach (var newspaper in newspapers)
            {
                Console.WriteLine("[{0}] -- Printed on: {1} with {2} ads", newspaper.Id, newspaper.IssueDate.ToShortDateString(), newspaper.AdList.Count);
            }
            
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
