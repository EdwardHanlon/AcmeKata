using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Entities.Interfaces;
using AcmeKata.Models;

namespace AcmeKata.Entities.Concrete
{
    public class AccessDataWriter : IDataWriter
    {
        private readonly string connStr;

        public AccessDataWriter()
        {
            connStr = AppDomain.CurrentDomain.GetData("DataDirectory") + @"\Acme Newspapers.accdb";
        }

        public void SaveNewNewspaper(Newspaper newspaper)
        {
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                var cmd = new OleDbCommand("", conn);
                cmd.CommandText = @"INSERT INTO [Newspapers] (IssueDate) VALUES (@a)";
                cmd.Parameters.Add(new OleDbParameter("a", newspaper.IssueDate.ToOADate()));

                cmd.ExecuteNonQuery();

                foreach (var ad in newspaper.AdList)
                {
                    var adCmd = new OleDbCommand("", conn);
                    adCmd.CommandText = @"INSERT INTO [Ads] (NewspaperId, Name) VALUES (@a, @b)";

                    adCmd.Parameters.Add(new OleDbParameter("a", newspaper.Id));
                    adCmd.Parameters.Add(new OleDbParameter("b", ad.Name));

                    adCmd.ExecuteNonQuery();
                }
            }
        }
        
        public void SaveNewAd(int newspaperId, Ad ad)
        {
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                var adCmd = new OleDbCommand("", conn);
                adCmd.CommandText = @"INSERT INTO [Ads] (NewspaperId, Name) VALUES (@a, @b)";

                adCmd.Parameters.Add(new OleDbParameter("a", newspaperId));
                adCmd.Parameters.Add(new OleDbParameter("b", ad.Name));

                adCmd.ExecuteNonQuery();
            }
        }
    }
}
