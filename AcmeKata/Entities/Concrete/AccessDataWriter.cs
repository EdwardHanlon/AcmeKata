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
    class AccessDataWriter : IDataWriter
    {
        private readonly string connStr;

        public AccessDataWriter()
        {
            connStr = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Data\Acme Newspapers.accdb";
        }

        public void SaveNewNewspapers(IEnumerable<Newspaper> newspapers)
        {
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();

                foreach (var newspaper in newspapers)
                {
                    var cmd = new OleDbCommand("", conn);
                    cmd.CommandText = @"INSERT INTO [Newspapers] (IssueDate) VALUES (@a)";
                    cmd.Parameters.Add(new OleDbParameter("a", newspaper.IssueDate.ToOADate()));

                    cmd.ExecuteNonQuery();

                    //Get the PK Given to Newspaper to be used as foreign key
                    var cmdNewId = new OleDbCommand("SELECT @@IDENTITY", conn);
                    var reader = cmdNewId.ExecuteReader();
                    reader.Read();
                    int pkGiven = Convert.ToInt32(reader.GetValue(0));

                    foreach (var ad in newspaper.AdList)
                    {
                        var adCmd = new OleDbCommand("", conn);
                        adCmd.CommandText = @"INSERT INTO [Ads] (NewspaperId, Name) VALUES (@a, @b)";

                        adCmd.Parameters.Add(new OleDbParameter("a", pkGiven));
                        adCmd.Parameters.Add(new OleDbParameter("b", ad.Name));

                        adCmd.ExecuteNonQuery();
                    } 
                }
            }
        }

        public void SaveNewAds(Newspaper newspaper)
        {
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                
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
    }
}
