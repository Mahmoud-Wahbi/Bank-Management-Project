using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class PhoneDataAccess
    {

        public static int AddNewPhone(int PersonId, string Phone)
        {
            int PhoneId = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Phones (PersonId,Phone) VALUES (@PersonId ,@Phone);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {

                connection.Open();

                object DataObject = command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int ReturnedId))
                {
                    PhoneId = ReturnedId;
                }
                else
                {
                    PhoneId = -1;
                }


            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }

            return PhoneId;
        }

        public static bool IsPhoneExist(string PhoneNumber)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);


            string Query = "Select 1 From Phones Where Phone = @Phone";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Phone", PhoneNumber);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }

                Reader.Close();

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }


            return IsExist;
        }

        public static bool IsPhoneExist(int PersonId)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 from Phones Where PersonId = @PersonId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }

                reader.Close();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }


        public static bool DeletePhone(int PersonId)
        {

            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);


            string Query = "Delete From Phones where PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();

                AffectedRows = Command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;
        }

        public static DataTable GetAllPhones(int PersonId)
        {
            DataTable dtPhones = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Phones WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {

                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPhones.Load(Reader);
                }

                Reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }


            return dtPhones;
        }


        public static DataTable GetPhone(int PersonId)
        {
            DataTable dtPhones = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * FROM Phones WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {

                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPhones.Load(Reader);
                }
                else
                {
                    dtPhones = null;
                }

                Reader.Close();

            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }



            return dtPhones;
        }

       

    }
}
