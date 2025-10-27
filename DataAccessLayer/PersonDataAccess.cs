using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DataAccesLayer
{
    public class PersonDataAccess
    {

        public static int AddNewPerson(int CountryId, string FirstName, string LastName, string Email,
             string Address, char Gender, DateTime BirthDate, string ImageUrl)
        {
            int ID = -1;


            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = $"Insert Into Persons (CountryId,FirstName,LastName,Email,Address,Gender,BirthDate,ImageUrl) " +
                $"values(@CountryId,@FirstName,@LastName,@Email,@Address,@Gender,@BirthDate,@ImageUrl);" +
                $"SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@CountryId", CountryId);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@BirthDate", BirthDate);



            if (string.IsNullOrEmpty(ImageUrl))
                Command.Parameters.AddWithValue("@ImageUrl", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImageUrl", ImageUrl);


            try
            {
                connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null && int.TryParse(DataObject.ToString(), out int EnteredId))
                {
                    ID = EnteredId;
                }
                else
                {
                    ID = -1;
                }

            }
            catch
            {
                ID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }

        public static bool GetPersonById(int PersonId, ref int CountryId, ref string FirstName, ref string LastName,
           ref string Email, ref string Address, ref char Gender, ref DateTime BirthDate, ref string ImageUrl)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * From Persons Where ID = @Id";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Id", PersonId);

            try
            {

                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    CountryId = (int)Reader["CountryId"];
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Address = (string)Reader["Address"];
                    Gender = Convert.ToChar(Reader["Gender"]);
                    BirthDate = (DateTime)Reader["BirthDate"];
                    ImageUrl = Reader["ImageUrl"] == DBNull.Value ? "" : (string)Reader["ImageUrl"];
                }
                else
                {
                    IsFound = false;
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



            return IsFound;
        }

        public static bool GetPersonByEmail(string Email, ref int PersonId, ref int CountryId, ref string FirstName,
    ref string LastName, ref string Address, ref char Gender, ref DateTime BirthDate, ref string ImageUrl)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Persons WHERE Email = @Email";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    PersonId = (int)Reader["ID"];
                    CountryId = (int)Reader["CountryId"];
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Address = (string)Reader["Address"];
                    Gender = Convert.ToChar(Reader["Gender"]);
                    BirthDate = (DateTime)Reader["BirthDate"];
                    ImageUrl = Reader["ImageUrl"] == DBNull.Value ? "" : (string)Reader["ImageUrl"];
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

            return IsFound;
        }


        public static bool UpdatePerson(int Id, int CountryId, string FirstName, string LastName,
            string Email, string Address, char Gender, DateTime BirthDate, string ImageUel)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "UPDATE Persons " +
                "SET CountryId = @CountryId, " +
                "FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Email = @Email, " +
                "Address = @Address, " +
                "Gender = @Gender, " +
                "BirthDate = @BirthDate, " +
                "ImageUrl = @ImageUrl " +
                "WHERE ID = @ID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@CountryId", CountryId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);

            if (string.IsNullOrEmpty(ImageUel))
                command.Parameters.AddWithValue("@ImageUrl", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImageUrl", ImageUel);

            command.Parameters.AddWithValue("@ID", Id);


            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }


            return RowsAffected > 0;

        }

        public static bool DeletePerson(int Id)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Delete From Persons Where ID = @Id";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Id", Id);

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


            return RowsAffected != 0;


        }

        public static bool IsPersonExist(int Id)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Persons Where ID = @Id";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

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

        public static int GetPersonIdByEmail(string Email)
        {
            int Id = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT ID FROM Persons Where Email = @Email";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    Id = reader.GetInt32(0);

                }
                else
                {
                    Id = -1;
                }
                reader.Close();
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

        public static bool IsEmailExist(string Email)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);


            string Query = "Select 1 From Persons Where Email = @Email";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Email", Email);

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

    }
}
