using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Countries_CurrenciesDataAccess
    {

        public static bool GetCurrencyByCountryId(int CountryId, ref int CurrencyId, ref Decimal RateOn1Dollar,
            ref int Country_Currency_Id, ref string CurrencyName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"Select * From Countries_Currencies WHERE CountryId = @CountryId";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryId", CountryId);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    CurrencyId = (int)Reader["CurrencyId"];
                    RateOn1Dollar = (Decimal)Reader["Rate_On_1$"];
                    Country_Currency_Id = (int)Reader["Country_Currency_Id"];
                    CurrencyName = (string)Reader["CurrencyName"];
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

        public static bool GetCurrencyByCurrencyName(string CurrencyName, ref int CountryId, ref int CurrencyId, ref Decimal RateOn1Dollar,
          ref int Country_Currency_Id)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"Select * From Countries_Currencies WHERE CurrencyName = @CurrencyName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CurrencyName", CurrencyName);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    CountryId = (int)Reader["CountryId"];
                    RateOn1Dollar = (Decimal)Reader["Rate_On_1$"];
                    Country_Currency_Id = (int)Reader["Country_Currency_Id"];
                    CurrencyId = (int)Reader["CurrencyId"];
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
        
        public static bool GetExchangeRateByCountry(int CountryId, ref Decimal ExchangeRate)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select Rate_On_1$
                                from Countries_Currencies
                                where CountryId = @CountryId";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@CountryId", CountryId);

            try
            {
                connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                {
                    ExchangeRate = (Decimal)Reader[0];
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

        

    }
}
