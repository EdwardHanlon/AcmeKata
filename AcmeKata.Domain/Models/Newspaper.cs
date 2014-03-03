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

        //Constructor with no ID allows for non-RDMS implementation
        public Newspaper(DateTime? _issueDate)
        {
            AdList = new List<Ad>();
            if (_issueDate != null) IssueDate = (DateTime)_issueDate;
        }

        public Newspaper(DateTime? _issueDate, int id)
        {
            Id = id;
            if (_issueDate != null) IssueDate = (DateTime) _issueDate;
            AdList = new List<Ad>();
        }

        public void PlaceAd(Ad newAd)
        {
            AdList.Add(newAd);
        }
    }
}
