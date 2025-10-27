using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class UserDataAccess
    {

        public static int AddNewUser(int PersonId, string UserName, string Password, int Permissions)
        {
            int Id = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users (PersonId,UserName,Password,Permissions) 
                            VALUES (@PersonId , @UserName , @Password , @Permissions);
                            select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Permissions);

            try
            {
                connection.Open();

                object DataObject = command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int GeneratedId))
                {
                    Id = GeneratedId;
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
                connection.Close();
            }

            return Id;
        }

        public static bool GetUserById(int UserId, ref int PersonId, ref string UserName, ref string Password, ref int Permissions)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * From Users where UserId = @UserId";

            SqlCommand command = new SqlCommand(@Query, connection);

            command.Parameters.AddWithValue("@UserId", UserId);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PersonId = (int)reader["PersonId"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["password"];
                    Permissions = (int)reader["Permissions"];

                    reader.Close();
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
                connection.Close();
            }



            return IsFound;
        }

        public static bool GetUserByUserName(string userName, ref int personId, ref string password, ref int permissions, ref int userId)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    userId = (int)reader["UserId"];
                    personId = (int)reader["PersonId"];
                    password = (string)reader["Password"];
                    permissions = (int)reader["Permissions"];

                    reader.Close();
                }
                else
                {
                    isFound = false;
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

            return isFound;
        }

        public static bool GetUserByEmail(string Email, ref int UserId, ref int PersonId, ref string UserName, ref string Password, ref int Permissions)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.* 
                     FROM Users 
                     INNER JOIN Persons ON Users.PersonId = Persons.ID 
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

                    UserId = (int)Reader["UserId"];
                    PersonId = (int)Reader["PersonId"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
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

        public static bool GetUserByPersonId(int PersonId, ref int UserId, ref string UserName, ref string Password, ref int Permissions)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Users WHERE PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    UserId = (int)Reader["UserId"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
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



        public static bool UpdateUser(int UserId, int PersonId, string UserName, string Password, int Permissions)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"UPDATE USERS SET 
                                PersonId = @PersonId ,
                                UserName = @UserName ,
                                Password = @Password ,
                                Permissions = @Permissions 
                                WHERE UserId = @UserId";

            SqlCommand Command = new SqlCommand(@Query, connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
            Command.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteOnlyUser(int UserId)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Delete From Users where UserId = @UserId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@UserId", UserId);

            try
            {

                connection.Open();

                RowsAffected = Command.ExecuteNonQuery();


            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteOnlyUserByPersonId(int PersonId)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Delete From Users where PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {

                connection.Open();

                RowsAffected = Command.ExecuteNonQuery();


            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteUser(string UserName)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "DELETE FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

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

            return RowsAffected > 0;
        }


        public static bool IsUserExist(int UserId)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 From Users Where UserId = @UserId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@UserId", UserId);

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

        public static bool IsUserExist(string UserName)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 From Users Where UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@UserName", UserName);

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

        public static bool IsUserExistByPersonId(int PersonId)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select 1 From Users Where PersonId = @PersonId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

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


        public static DataTable GetUsersTable()
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT * 
                     FROM Persons  
                     INNER JOIN Users ON Users.PersonId = Persons.ID";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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

            return dtUsers;
        }


        public static DataTable GetShortUsersTable()
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.UserName, Persons.FirstName, Persons.LastName, Users.Permissions 
                     FROM Users 
                     INNER JOIN Persons ON Users.PersonId = Persons.ID";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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

            return dtUsers;
        }

        public static DataTable GetNextOrPrevRows(int OffsetRows, int FetchRows, string SearchColumn = null, object SearchValue = null)
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"
                    SELECT * 
                     FROM Persons  
                     INNER JOIN Users ON Users.PersonId = Persons.ID
                   ";

            if (!string.IsNullOrEmpty(SearchColumn) && SearchValue != null)
            {
                // If search value is string -> use LIKE
                if (SearchValue is string)
                    Query += $" WHERE {SearchColumn} LIKE @SearchValue ";
                else
                    Query += $" WHERE {SearchColumn} = @SearchValue ";
            }

            Query += @"
               ORDER BY Users.UserId
               OFFSET @OffsetRows ROWS FETCH NEXT @FetchRows ROWS ONLY;
              ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@OffsetRows", OffsetRows);
            command.Parameters.AddWithValue("@FetchRows", FetchRows);

            if (!string.IsNullOrEmpty(SearchColumn) && SearchValue != null)
            {
                if (SearchValue is string)
                    command.Parameters.AddWithValue("@SearchValue", "%" + SearchValue.ToString() + "%");
                else
                    command.Parameters.AddWithValue("@SearchValue", SearchValue);
            }

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
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

            return dtUsers;
        }

        public static bool RegesterALogin(int UserId, DateTime RegesterDate, string UserName, string Password, int Permissions)
        {
            bool IsInserted = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = $"INSERT INTO Login_Regesters (UserId, RegesterDate, UserName, Password, Permissions) " +
                           $"VALUES (@UserId, @RegesterDate, @UserName, @Password, @Permissions); " +
                           $"SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserId", UserId);
            Command.Parameters.AddWithValue("@RegesterDate", RegesterDate);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);

            try
            {
                Connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int ReturnedId) && ReturnedId > 0)
                {
                    IsInserted = true;
                }
            }
            catch
            {
                IsInserted = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsInserted;
        }

    }
}
