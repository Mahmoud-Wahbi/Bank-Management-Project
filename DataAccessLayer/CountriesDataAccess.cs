using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class CountriesDataAccess
    {

        public static DataTable GetCountries()
        {
            DataTable dt = new DataTable();


            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "Select * FROM Countries";

            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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



            return dt;
        }

        public static byte GetCountryIdByCountryName(string CountryName)
        {

            byte CountryId = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT CountryId FROM Countries WHERE CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object DataObject = Command.ExecuteScalar();

                if (DataObject != null && byte.TryParse(DataObject.ToString(), out byte ReturnedId))
                {
                    CountryId = ReturnedId;
                }
                else
                {
                    CountryId = 0;
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


            return CountryId;
        }

        public static bool GetCountryById(int CountryId, ref string CountryName, ref string CountryCode)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries WHERE CountryId = @Id";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Id", CountryId);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    CountryName = (string)Reader["CountryName"];
                    CountryCode = (string)Reader["CountryCode"];
                }
                else
                {
                    return false;
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

        public static DataTable GetAllCurrenciesNames()
        {
            DataTable dtCurrenciesNames = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "select CurrencyName  from Currencies;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtCurrenciesNames.Load(reader);
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }


            return dtCurrenciesNames;
        }


        public static string GetCountryFlag(int countryId)
        {
            string flagPath = string.Empty;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT FlagPath FROM Countries WHERE CountryId = @CountryId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryId", countryId);

            try
            {
                connection.Open();

                object dataObject = command.ExecuteScalar();

                if (dataObject != null)
                {
                    flagPath = dataObject.ToString();
                }
                else
                {
                    flagPath = string.Empty; 
                }
            }
            catch
            {
                return string.Empty; 
            }
            finally
            {
                connection.Close();
            }

            return flagPath;
        }

        public static string GetCountryFlag(string CountryName)
        {
            string flagPath = string.Empty;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT FlagPath FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object dataObject = command.ExecuteScalar();

                if (dataObject != null)
                {
                    flagPath = dataObject.ToString();
                }
                else
                {
                    flagPath = string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                connection.Close();
            }

            return flagPath;
        }

    }
}
