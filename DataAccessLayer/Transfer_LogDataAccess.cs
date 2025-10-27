using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Transfer_LogDataAccess
    {

        public static int AddNewTransferRecord(int ClientIdFrom, int ClientIdTo, int UserId,
    Decimal Amount, Decimal Fees, Decimal SourceBalance, string SourceCurrencyName,
    Decimal DestinationBalance, string DestinationCurrencyName, DateTime TransferDate,
    string Notes, int PersonId)
        {
            int RecordId = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TransferLogs(ClientId_From, ClientId_To, UserId, SourceBalance, SourceCurrencyName, 
                        DestinationBalance, DestinationCurrencyName, Amount, Fees, Date, Notes , PersonId) 
                     VALUES (@ClientIdFrom, @ClientIdTo, @UserId, @SourceBalance, @SourceCurrencyName,
                             @DestinationBalance, @DestinationCurrencyName, @Amount, @Fees, @TransferDate, @Notes , @PersonId);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ClientIdFrom", ClientIdFrom);
            command.Parameters.AddWithValue("@ClientIdTo", ClientIdTo);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@SourceBalance", SourceBalance);
            command.Parameters.AddWithValue("@SourceCurrencyName", SourceCurrencyName);
            command.Parameters.AddWithValue("@DestinationBalance", DestinationBalance);
            command.Parameters.AddWithValue("@DestinationCurrencyName", DestinationCurrencyName);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@TransferDate", TransferDate);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            try
            {
                Connection.Open();
                object DataObject = command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int ReturnedId))
                    RecordId = ReturnedId;
                else
                    RecordId = -1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Connection.Close();
            }

            return RecordId;
        }


        public static bool GetTransferLogById(int TransferId,
    ref int ClientIdFrom,
    ref int ClientIdTo,
    ref int UserId,
    ref decimal SourceBalance,
    ref string SourceCurrencyName,
    ref decimal DestinationBalance,
    ref string DestinationCurrencyName,
    ref decimal Amount,
    ref decimal Fees,
    ref DateTime TransferDate,
    ref string Notes,
    ref int PersonId
            )
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TransferLogs WHERE TransferId = @Id";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Id", TransferId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ClientIdFrom = (int)reader["ClientId_From"];
                    ClientIdTo = (int)reader["ClientId_To"];
                    UserId = (int)reader["UserId"];
                    SourceBalance = (decimal)reader["SourceBalance"];
                    SourceCurrencyName = (string)reader["SourceCurrencyName"];
                    DestinationBalance = (decimal)reader["DestinationBalance"];
                    DestinationCurrencyName = (string)reader["DestinationCurrencyName"];
                    Amount = (decimal)reader["Amount"];
                    Fees = (decimal)reader["Fees"];
                    TransferDate = (DateTime)reader["Date"];
                    Notes = reader["Notes"] == DBNull.Value ? string.Empty : (string)reader["Notes"];
                    PersonId = (int)reader["PersonId"];
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

            return IsFound;
        }


        public static DataTable GetTransferLogs()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TransferLogs";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteTransferLogById(int TransferId)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "DELETE FROM TransferLogs WHERE TransferId = @TransferId";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TransferId", TransferId);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected != 0;
        }

        public static bool DeleteTransferLogByClientId(int ClientID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "DELETE FROM TransferLogs WHERE ClientId_From = @ClientID or ClientId_To = @ClientID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected != 0;
        }

        public static bool DeleteTransferLogByUserId(int UserId)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "DELETE FROM TransferLogs WHERE UserId = @UserId";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected != 0;
        }

        public static bool DeleteTransferLogByPersonId(int PersonId)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "DELETE FROM TransferLogs WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected != 0;
        }


        public static bool UpdateTransferLog(
                                                int TransferId,
                                                int ClientIdFrom,
                                                int ClientIdTo,
                                                int UserId,
                                                decimal SourceBalance,
                                                string SourceCurrencyName,
                                                decimal DestinationBalance,
                                                string DestinationCurrencyName,
                                                decimal Amount,
                                                decimal Fees,
                                                DateTime TransferDate,
                                                string Notes,
                                                int PersonId
                                            )
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"UPDATE TransferLogs SET
                        ClientId_From = @ClientIdFrom,
                        ClientId_To = @ClientIdTo,
                        UserId = @UserId,
                        SourceBalance = @SourceBalance,
                        SourceCurrencyName = @SourceCurrencyName,
                        DestinationBalance = @DestinationBalance,
                        DestinationCurrencyName = @DestinationCurrencyName,
                        Amount = @Amount,
                        Fees = @Fees,
                        Date = @TransferDate,
                        Notes = @Notes,
                        PersonId = @PersonId
                    WHERE TransferId = @TransferId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientIdFrom", ClientIdFrom);
            command.Parameters.AddWithValue("@ClientIdTo", ClientIdTo);
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@SourceBalance", SourceBalance);
            command.Parameters.AddWithValue("@SourceCurrencyName", SourceCurrencyName);
            command.Parameters.AddWithValue("@DestinationBalance", DestinationBalance);
            command.Parameters.AddWithValue("@DestinationCurrencyName", DestinationCurrencyName);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@TransferDate", TransferDate);
            command.Parameters.AddWithValue("@TransferId", TransferId);
            command.Parameters.AddWithValue("@PersonId", PersonId);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected != 0;
        }


        public static bool IsTransferLogExistByClientId(int clientId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM TransferLogs WHERE ClientId_From = @ClientId  or ClientId_To = @ClientId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", clientId);

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

        public static bool IsTransferLogExistByUserId(int userId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM TransferLogs WHERE UserId = @UserId";

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

        public static bool IsTransferLogExistByPersonId(int PersonId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM TransferLogs WHERE PersonId = @PersonId";

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

        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows, string accountNumber = null)
        {
            DataTable table = new DataTable();

            using (SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string Query = @"
                               SELECT TransferId, ClientsFrom.AccountNumber AS FromAccount, ClientsTo.AccountNumber AS ToAccount,
                               SourceBalance, SourceCurrencyName, DestinationBalance, DestinationCurrencyName,
                               Amount, Fees, Date, Notes
                                FROM TransferLogs
                                INNER JOIN Clients AS ClientsFrom ON TransferLogs.ClientId_From = ClientsFrom.ClientId
                                INNER JOIN Clients AS ClientsTo   ON TransferLogs.ClientId_To   = ClientsTo.ClientId
                            ";

                // If accountNumber is provided, filter results
                if (!string.IsNullOrEmpty(accountNumber))
                {
                    Query += "WHERE ClientsFrom.AccountNumber LIKE @AccountNumber Or ClientsTo.AccountNumber LIKE @AccountNumber";
                }

                Query += @"
                            ORDER BY TransferLogs.Date DESC
                            OFFSET @OffsetRows ROWS FETCH NEXT @FetchRows ROWS ONLY;
                        ";

                SqlCommand command = new SqlCommand(Query, Connection);

                command.Parameters.AddWithValue("@OffsetRows", OffsetRows);
                command.Parameters.AddWithValue("@FetchRows", FetchRows);

                if (!string.IsNullOrEmpty(accountNumber))
                    command.Parameters.AddWithValue("@AccountNumber", "%" + accountNumber + "%");

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        table.Load(Reader);
                    }

                    Reader.Close();
                }
                catch
                {
                }
                finally
                {
                    Connection.Close();
                }
            }

            return table;
        }
    }
}
