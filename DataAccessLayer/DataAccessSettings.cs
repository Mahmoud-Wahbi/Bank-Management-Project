using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    internal class DataAccessSettings
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\BankDB.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
    

