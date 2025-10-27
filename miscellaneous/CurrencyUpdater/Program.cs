using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;

public class Program
{
    private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/USD";

    public static async Task Main(string[] args)
    {
        Console.WriteLine($"[{DateTime.Now}] Starting currency rate update process...");

        try
        {
            // --- 1. Read connection string from App.config ---
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("ConnectionString not found in App.config file.");
            }

            // --- 2. Fetch data from API ---
            var rates = await FetchRatesFromApi();
            Console.WriteLine("Successfully fetched rates from the internet.");

            // --- 3. Update the database ---
            await UpdateDatabase(rates, connectionString);
            Console.WriteLine("Database updated successfully.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine($"[{DateTime.Now}] Update process finished. Press any key to exit.");
        Console.ReadKey();
    }

    private static async Task<JObject> FetchRatesFromApi()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetStringAsync(ApiUrl);
            var data = JObject.Parse(response);
            if (data["rates"] == null)
            {
                throw new Exception("The API response does not contain exchange rates.");
            }
            return (JObject)data["rates"];
        }
    }

    private static async Task UpdateDatabase(JObject rates, string connectionString)
    {
        int updatedCurrencies = 0;
        int updatedCountriesCurrencies = 0;

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            foreach (var rate in rates)
            {
                string currencyCode = rate.Key;
                decimal currencyValue = (decimal)rate.Value;

                var cmdUpdateCurrencies = new SqlCommand("UPDATE Currencies SET Rate_On_1$ = @Rate WHERE CurrencyCode = @Code", connection); cmdUpdateCurrencies.Parameters.AddWithValue("@Rate", currencyValue);
                cmdUpdateCurrencies.Parameters.AddWithValue("@Code", currencyCode);
                int result1 = await cmdUpdateCurrencies.ExecuteNonQueryAsync();

                if (result1 > 0)
                {
                    updatedCurrencies += result1;
                    Console.WriteLine($" - (Currencies) Updated rate for {currencyCode} to {currencyValue}");

                    var cmdUpdateCountries = new SqlCommand(
                     "UPDATE Countries_Currencies SET Rate_On_1$ = @Rate WHERE CurrencyId IN (SELECT CurrencyId FROM Currencies WHERE CurrencyCode = @Code)",
                     connection);
                    cmdUpdateCountries.Parameters.AddWithValue("@Rate", currencyValue);
                    cmdUpdateCountries.Parameters.AddWithValue("@Code", currencyCode);
                    int result2 = await cmdUpdateCountries.ExecuteNonQueryAsync();

                    if (result2 > 0)
                    {
                        updatedCountriesCurrencies += result2;
                    }
                }
            }
        }
        Console.WriteLine($"\nUpdate complete.");
        Console.WriteLine($" - {updatedCurrencies} records updated in Currencies table.");
        Console.WriteLine($" - {updatedCountriesCurrencies} records updated in Countries_Currencies table.");
    }
}