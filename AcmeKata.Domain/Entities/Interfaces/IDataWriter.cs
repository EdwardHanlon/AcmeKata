using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Models;

namespace AcmeKata.Entities.Interfaces
{
    public interface IDataWriter
    {
        void SaveNewNewspaper(Newspaper newspaper);
        void SaveNewAd(int newspaperId, Ad ad);
    }
}
