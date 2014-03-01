using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Models;

namespace AcmeKata.Entities.Interfaces
{
    interface IDataWriter
    {
        void SaveNewNewspapers(IEnumerable<Newspaper> newspaper);
        void SaveNewAds(Newspaper newspaper);
    }
}
