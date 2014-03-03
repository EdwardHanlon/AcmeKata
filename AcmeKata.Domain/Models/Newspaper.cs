using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeKata.Models
{
    public class Newspaper
    {
        public int Id { get; set; }
        public List<Ad> AdList { get; set; }

        private DateTime? issueDate;
        public DateTime IssueDate
        {
            get { return issueDate.HasValue ? issueDate.Value : DateTime.Now.Date; }
            set { issueDate = value; }
        }        
        
        public Newspaper()
        {
            AdList = new List<Ad>();
        }

        public Newspaper(DateTime issueDate, int id)
        {
            Id = id;
            IssueDate = issueDate;
            AdList = new List<Ad>();
        }

        public void PlaceAd(Ad newAd)
        {
            AdList.Add(newAd);
        }

        public IEnumerable<Ad> GetAds()
        {
            return AdList;
        }
    }
}
