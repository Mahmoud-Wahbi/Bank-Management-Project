using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace DataAccesLayer
{
    public class ClientDataAccess
    {

        public static int AddNewClient(int PersonId, string AccountNumber, Decimal Balance, string PinCode)
        {
            int Id = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Clients (PersonId,AccountNumber,Balance,PinCode) VALUES (@PersonId,@AccountNumber,@Balance,@PinCode);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            Command.Parameters.AddWithValue("@Balance", Balance);
            Command.Parameters.AddWithValue("@PinCode", PinCode);


            try
            {

                Connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int CreatedId))
                {
                    Id = CreatedId;
                }
                else
                {
                    Id = -1;
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



            return Id;
        }

        public static bool GetClientById(int ClientIdId, ref int PersonId, ref string ClientAccountNumber, ref Decimal Balance, ref string PinCode)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * From Clients Where ClientId = @Id ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", ClientIdId);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    ClientAccountNumber = (string)Reader["AccountNumber"];
                    PersonId = (int)Reader["PersonID"];
                    Balance = (Decimal)Reader["Balance"];
                    PinCode = (string)Reader["PinCode"];
                }
                else
                {
                    return false;
                }
                Reader.Close();
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

        public static bool GetClientByAccountNumber(string ClientAccountNumber, ref int PersonId, ref int ClientIdId, ref Decimal Balance, ref string PinCode)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * From Clients Where AccountNumber = @AccountNumber";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@AccountNumber", ClientAccountNumber);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    ClientIdId = (int)Reader["ClientId"];
                    PersonId = (int)Reader["PersonID"];
                    Balance = (Decimal)Reader["Balance"];
                    PinCode = (string)Reader["PinCode"];
                }
                else
                {
                    return false;
                }
                Reader.Close();

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


        public static bool GetClientByEmail(string Email, ref int ClientId, ref int PersonId, ref string ClientAccountNumber, ref Decimal Balance, ref string PinCode)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Clients.*
                     FROM Clients 
                     INNER JOIN Persons ON Clients.PersonID = Persons.ID 
                     WHERE Persons.Email = @Email";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Email", Email);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ClientId = (int)Reader["ClientID"];
                    PersonId = (int)Reader["PersonID"];
                    ClientAccountNumber = (string)Reader["AccountNumber"];
                    Balance = (decimal)Reader["Balance"];
                    PinCode = (string)Reader["PinCode"];
                }
                else
                {
                    return false;
                }
                Reader.Close();
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


        public static bool GetClientByPersonId(int PersonId, ref int ClientId, ref string ClientAccountNumber, ref Decimal Balance, ref string PinCode)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * from Clients where PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ClientId = (int)Reader["ClientId"];
                    ClientAccountNumber = (string)Reader["AccountNumber"];
                    Balance = (Decimal)Reader["Balance"];
                    PinCode = (string)Reader["PinCode"];

                }

                Reader.Close();

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


        public static bool UpdateClient(int ClientId, string AccountNumber, Decimal Balance, string PinCode)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"UPDATE CLIENTS SET
                        AccountNumber = @AccountNumber,
                        Balance = @Balance,
                        PinCode = @PinCode
                        WHERE ClientId = @ClientId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@ClientId", ClientId);

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

        public static bool DeleteClientById(int ClientId)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Delete From Clients Where ClientId = @ClientId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientId", ClientId);

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

        public static bool DeleteClientByPersonId(int PersonID)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Delete From Clients Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static bool IsClientExist(int ClientId)
        {

            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 From Clients Where ClientId = @ClientId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@ClientId", ClientId);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
                Reader.Close();
            }
            catch
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }



            return isExist;

        }

        public static bool IsClientExistByAccountNumber(string AccountNumber)
        {

            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 From Clients Where AccountNumber = @AccountNumber";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
                Reader.Close();
            }
            catch
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }



            return isExist;

        }

        public static bool IsClientExistByPersonId(int PersonId)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT 1 FROM Clients WHERE PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }

                Reader.Close();
            }
            catch
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }


        public static DataTable GetClientsTable()
        {
            DataTable dtClients = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * From Clients INNER JOIN PERSONS ON Clients.PersonId = Persons.ID";

            SqlCommand command = new SqlCommand(Query, connection);


            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtClients.Load(Reader);
                }

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtClients;
        }

        public static DataTable GetShortClientsTable()
        {
            DataTable dtClients = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"Select Persons.FirstName , Persons.LastName , Clients.AccountNumber , Clients.Balance
                                From Clients
                                INNER JOIN PERSONS ON Clients.PersonId = Persons.ID";

            SqlCommand command = new SqlCommand(Query, connection);


            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtClients.Load(Reader);
                }

                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dtClients;
        }

        public static bool UpdateBalance(decimal Balance, int ClientId)
        {

            bool IsUpdated = false;

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"UPDATE Clients SET Balance = @Balance WHERE ClientId = @ClientId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@ClientId", ClientId);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

                IsUpdated = (RowsAffected > 0);

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();

            }

            return IsUpdated;
        }


        public static Decimal GetTotalBalances()
        {
            Decimal TotalBalance = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Quert = @"select SUM(Balance) 
                            From Clients";

            SqlCommand command = new SqlCommand(Quert, connection);

            try
            {
                connection.Open();


                object DataObject = command.ExecuteScalar();

                if (DataObject != null && Decimal.TryParse(DataObject.ToString(), out Decimal Balances))
                {
                    TotalBalance = Balances;
                }
                else
                {
                    return 0;
                }


            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }


            return TotalBalance;
        }
         
        public static DataTable GetNextOrPrevRows(
            int OffsetRows,
            int FetchRows,
            string SearchColumn = null,
            object SearchValue = null)
        {
            DataTable table = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"
                    SELECT Clients.*, Persons.*
                    FROM Clients
                    INNER JOIN Persons ON Clients.PersonId = Persons.ID
                    /**WHERE**/
                    ORDER BY Clients.ClientId
                    OFFSET @OffsetRows ROWS
                    FETCH NEXT @FetchRows ROWS ONLY;";

            if (!string.IsNullOrEmpty(SearchColumn) && SearchValue != null)
            {
                Query = Query.Replace("/**WHERE**/", $"WHERE {SearchColumn} LIKE @SearchValue");
            }
            else
            {
                Query = Query.Replace("/**WHERE**/", "");
            }

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@OffsetRows", OffsetRows);
            command.Parameters.AddWithValue("@FetchRows", FetchRows);

            if (!string.IsNullOrEmpty(SearchColumn) && SearchValue != null)
            {
                if (SearchValue is int)
                    command.Parameters.AddWithValue("@SearchValue", SearchValue); // exact match 
                else
                    command.Parameters.AddWithValue("@SearchValue", "%" + SearchValue.ToString() + "%"); // LIKE
            }

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

            return table;
        }

        public static DataTable GetTableSeachOf(string KeyWord, Common.SearchConstrants.enSearchMethod enSearchMethod)
        {
            DataTable table = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = string.Empty;
            SqlCommand command = null;

            try
            {
                Connection.Open();

                switch (enSearchMethod)
                {
                    case Common.SearchConstrants.enSearchMethod.ByFullName:
                        Query = @"SELECT * FROM Clients 
                          INNER JOIN Persons ON Clients.PersonId = Persons.ID
                          WHERE Persons.FirstName + ' ' + Persons.LastName LIKE '%' + @KeyWord + '%'";
                        command = new SqlCommand(Query, Connection);
                        command.Parameters.AddWithValue("@KeyWord", KeyWord);
                        break;

                    case Common.SearchConstrants.enSearchMethod.CountryId:
                        if (!int.TryParse(KeyWord, out int CountryId))
                            throw new ArgumentException("Invalid CountryId value");

                        Query = @"SELECT * FROM Clients 
                              INNER JOIN Persons ON Clients.PersonId = Persons.ID
                              WHERE Persons.CountryId = @CountryId";
                        command = new SqlCommand(Query, Connection);
                        command.Parameters.AddWithValue("@CountryId", CountryId);
                        break;

                    case Common.SearchConstrants.enSearchMethod.ClientAccountNumber:
                        Query = @"SELECT * FROM Clients 
                          INNER JOIN Persons ON Clients.PersonId = Persons.ID
                          WHERE Clients.AccountNumber LIKE '%' + @KeyWord + '%'";
                        command = new SqlCommand(Query, Connection);
                        command.Parameters.AddWithValue("@KeyWord", KeyWord);
                        break;

                    case Common.SearchConstrants.enSearchMethod.ClientId:
                        if (!int.TryParse(KeyWord, out int ClientId))
                            throw new ArgumentException("Invalid CountryId value");

                        Query = @"SELECT * FROM Clients 
                              INNER JOIN Persons ON Clients.PersonId = Persons.ID
                              WHERE Clients.ClientId = @ClientId";
                        command = new SqlCommand(Query, Connection);
                        command.Parameters.AddWithValue("@ClientId", ClientId);
                        break;

                    case Common.SearchConstrants.enSearchMethod.PersonId:
                        if (!int.TryParse(KeyWord, out int PersonId))
                            throw new ArgumentException("Invalid CountryId value");

                        Query = @"SELECT * FROM Clients 
                              INNER JOIN Persons ON Clients.PersonId = Persons.ID
                              WHERE Persons.ID = @PersonId";
                        command = new SqlCommand(Query, Connection);
                        command.Parameters.AddWithValue("@PersonId", PersonId);
                        break;

                }

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

            return table;
        }

        public static string GenerateRandomNextAccountNumber()
        {
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"-- 1. Declare variables to store the parts
                            DECLARE @RandomLetter CHAR(1);
                            DECLARE @HighestNumberForLetter INT;
                            DECLARE @NextNumber INT;

                            -- 2. Generate a random letter (A-Z)
                            -- 65 is the ASCII code for 'A' and 26 is the number of letters
                            SELECT @RandomLetter = CHAR(FLOOR(RAND(CHECKSUM(NEWID())) * 26) + 65);

                            -- 3. Parse all accounts into a temporary table (same code as before)
                            WITH ParsedAccounts AS (
                                SELECT
                                    LEFT(AccountNumber, 1) AS LetterPart,
                                    CAST(SUBSTRING(AccountNumber, 2, LEN(AccountNumber) - 1) AS INT) AS NumberPart
                                FROM
                                    Clients
                                WHERE
                                    ISNUMERIC(SUBSTRING(AccountNumber, 2, LEN(AccountNumber) - 1)) = 1
                                    AND LEN(AccountNumber) > 1
                            )
                            -- 4. Find the highest number *only for the random letter we selected*
                            SELECT @HighestNumberForLetter = MAX(NumberPart)
                            FROM ParsedAccounts
                            WHERE LetterPart = @RandomLetter;

                            -- 5. Calculate the next number
                            -- ISNULL(@HighestNumberForLetter, 0) means:
                            -- ""Use the highest number found. If no number was found (NULL), use 0""
                            -- (If you want new letters to start from 1000, replace 0 with 999)
                            SELECT @NextNumber = ISNULL(@HighestNumberForLetter, 0) + 1;

                            -- 6. Combine the random letter with the new number and return the result
                            SELECT @RandomLetter + CAST(@NextNumber AS VARCHAR(100)) AS NextAccountNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null)
                {
                    return DataObject.ToString();  
                }
                else
                {
                    return string.Empty;
                }

            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                Connection.Close();
            }
        }


    }
}
