using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeKata.Models;
using IDataReader = AcmeKata.Entities.Interfaces.IDataReader;

namespace AcmeKata.Entities.Concrete
{
    class AccessDataReader : IDataReader
    {
        private readonly string connStr;

        public AccessDataReader()
        {
            connStr = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Data\Acme Newspapers.accdb";
        }

        public IEnumerable<Newspaper> GetAllNewspapers()
        {
            var data = new DataSet();

            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                var cmd = new OleDbCommand("", conn);
                cmd.CommandText = @"SELECT [ID], [IssueDate] FROM [Newspapers];";
                var dataAdapter = new OleDbDataAdapter(cmd);
                dataAdapter.Fill(data, "Newspapers");
            }
            
            foreach (DataRow newspaper in data.Tables["Newspapers"].Rows)
            {
                DateTime parsedDate;
                DateTime.TryParse(newspaper.ItemArray[1].ToString(), out parsedDate);
                
                yield return new Newspaper
                {
                    Id = Convert.ToInt32(newspaper.ItemArray[0]),
                    AdList = GetAllAdsForNewspaperId(Convert.ToInt32(newspaper.ItemArray[0])).ToList(),
                    IssueDate = parsedDate
                };
            }
        }

        private IEnumerable<Ad> GetAllAdsForNewspaperId(int id)
        {
            var data = new DataSet();
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                var cmd = new OleDbCommand("", conn);
                cmd.CommandText = string.Format(@"SELECT [Name] FROM [Ads] WHERE [NewspaperId] = {0};", id);
                var dataAdapter = new OleDbDataAdapter(cmd);
                dataAdapter.Fill(data, "Ads");
            }

            return from DataRow ad in data.Tables["Ads"].Rows select new Ad
            {
                Name = ad.ItemArray[0].ToString()
            };
        }

        public int GetMaxId()
        {
            using (var conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", connStr)))
            {
                conn.Open();
                var cmdNewId = new OleDbCommand("SELECT Max([ID]) From [Newspapers]", conn);
                var reader = cmdNewId.ExecuteReader();
                reader.Read();

                if (!reader.IsDBNull(0))
                    return reader.GetInt32(0) + 1;

                return 1;
            }
        }
    }
}
