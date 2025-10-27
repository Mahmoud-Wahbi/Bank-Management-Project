using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class TransactionLogDataAccess
    {


        public static int AddTransactionLog(int UserId, int ClientId, string Currency, Decimal Amount, DateTime date, int Transaction_Type_Id, string Notes, int PersonId)
        {
            int TransactionId = 0;


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = $"insert into Transaction_Logs(UserId , ClientId , Currency , Amount , Date , Transaction_Type_Id , Notes , PersonId)" +
                                                        $" Values (@UserId , @ClientId , @Currency , @Amount , @Date , @Transaction_Type_Id,@notes , @PersonId);" +
                                                        $"SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserId", UserId);
            Command.Parameters.AddWithValue("@ClientId", ClientId);
            Command.Parameters.AddWithValue("@Currency", Currency);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@Date", date);
            Command.Parameters.AddWithValue("@Transaction_Type_Id", Transaction_Type_Id);
            Command.Parameters.AddWithValue("@PersonId", PersonId);

            if (string.IsNullOrEmpty(Notes))
            {
                Command.Parameters.AddWithValue("@notes", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@notes", Notes);
            }

            try
            {
                Connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int ReturnedId))
                {
                    TransactionId = ReturnedId;
                }
                else
                {
                    TransactionId = -1;
                }

            }
            catch
            {
                return -1;
            }
            finally
            {
                Connection.Close();
            }


            return TransactionId;
        }


        public static bool DeleteTransactionLogsByClientId(int clientId)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Transaction_Logs WHERE  clientId = @ClientId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", clientId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool DeleteTransactionLogsByUserId(int userId)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Transaction_Logs WHERE UserId = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }


        public static bool DeleteTransactionLogsByPersonId(int PersonId)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Transaction_Logs WHERE  PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool IsTransactionLogExistByClientId(int clientId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Select 1 FROM Transaction_Logs WHERE  clientId = @clientId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@clientId", clientId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
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

            return isExist;
        }

        public static bool IsTransactionLogExistByUserId(int userId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM Transaction_Logs WHERE UserId = @UserId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
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

            return isExist;
        }


        public static bool IsTransactionLogExistByPersonId(int PersonId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Select 1 FROM Transaction_Logs WHERE  PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
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

            return isExist;
        }


    }
}
