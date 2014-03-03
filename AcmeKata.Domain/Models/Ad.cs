using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeKata.Models
{
    public class Ad
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = string.IsNullOrEmpty(value) ? "" : value; }
        }
        
        public Ad(string adName = "")
        {
            Name = adName;
        }
    }
}
