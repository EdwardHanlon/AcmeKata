using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Entities.Concrete;
using AcmeKata.Entities.Interfaces;
using Ninject.Modules;

namespace AcmeKata.Modules
{
    class AcmeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataReader>().To<AccessDataReader>().InSingletonScope();
            Bind<IDataWriter>().To<AccessDataWriter>().InSingletonScope();
        }
    }
}
