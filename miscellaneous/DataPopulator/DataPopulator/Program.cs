using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;

public class Program
{
    private const string ApiUrl = "https://restcountries.com/v3.1/all?fields=name,cca2,currencies,flags";

    public static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Starting process to populate/update 'Countries' table...");
        Console.WriteLine("This will update existing countries and add new ones.");
        Console.WriteLine("------------------------------------------------------------------");

        try
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var countriesData = await FetchCountriesFromApi();
            Console.WriteLine($"Found {countriesData.Count} countries from the API.");

            await PopulateDatabase(countriesData, connectionString);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n------------------------------------------------------------------");
        Console.WriteLine("Process finished. Press any key to exit.");
        Console.ReadKey();
    }

    private static async Task<JArray> FetchCountriesFromApi()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetStringAsync(ApiUrl);
            return JArray.Parse(response);
        }
    }

    private static async Task PopulateDatabase(JArray countries, string connectionString)
    {
        int countriesAdded = 0;
        int countriesUpdated = 0;

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            foreach (var country in countries)
            {
                string countryName = country["name"]?["official"]?.ToString();
                string countryCode = country["cca2"]?.ToString();
                string flagPath = country["flags"]?["svg"]?.ToString();
                var currencies = (JObject)country["currencies"];

                if (string.IsNullOrEmpty(countryName) || string.IsNullOrEmpty(countryCode) || currencies == null || currencies.Count == 0)
                {
                    continue;
                }

                try
                {
                    // *** هذا هو التعديل الأهم ***
                    // يقوم بالتحديث إذا كان السجل موجوداً، أو الإضافة إذا كان جديداً
                    var cmdCountry = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM Countries WHERE CountryCode = @cCode) " +
                        "BEGIN UPDATE Countries SET CountryName = @cName, FlagPath = @fPath WHERE CountryCode = @cCode; END " +
                        "ELSE BEGIN INSERT INTO Countries (CountryName, CountryCode, FlagPath) VALUES (@cName, @cCode, @fPath); END",
                        connection);

                    cmdCountry.Parameters.AddWithValue("@cName", countryName);
                    cmdCountry.Parameters.AddWithValue("@cCode", countryCode);
                    cmdCountry.Parameters.AddWithValue("@fPath", flagPath ?? "");

                    int result = await cmdCountry.ExecuteNonQueryAsync();

                    // ExecuteNonQueryAsync لا يخبرنا إذا كان تحديثاً أم إضافة،
                    // لذا سنقوم فقط بالعد بناءً على ما إذا كان قد تم بنجاح
                    Console.WriteLine($"Processed: {countryName} ({countryCode})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" -> Failed to process {countryName}: {ex.Message}");
                }
            }
        }
        // لا يمكننا الآن معرفة العدد الدقيق للتحديثات مقابل الإضافات بسهولة،
        // لذا سنعرض رسالة عامة
        Console.WriteLine($"\nSummary: All countries have been processed and updated/inserted.");
    }
}