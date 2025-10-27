using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Transaction_TypeDataAccess
    {


        public static bool GetTransactionIdByName(string Name, ref int TransactionId)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * FROM Transaction_Types WHERE TransactionName = @Name ";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {

                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    TransactionId = (int)Reader["Transaction_Type_Id"];
                }
                else
                {
                    IsFound = false;
                }


            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }



            return IsFound;
        }


    }
}
