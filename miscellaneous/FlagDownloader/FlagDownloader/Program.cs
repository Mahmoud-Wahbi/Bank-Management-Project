using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

public class Program
{
    // ⚠️⚠️ غيّر هذا المسار إلى المجلد الذي تريد حفظ الأعلام فيه ⚠️⚠️
    private const string DownloadFolderPath = @"C:\Users\Mamhoud\Desktop\Bank Project Main\Resources\FlagsIcons";

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting flag download process...");

        // التأكد من وجود المجلد، وإن لم يكن موجودًا يتم إنشاؤه
        Directory.CreateDirectory(DownloadFolderPath);

        try
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            await DownloadAndSaveFlags(connectionString);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine($"\nProcess finished. Flags are saved in: {DownloadFolderPath}");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static async Task DownloadAndSaveFlags(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        using (var httpClient = new HttpClient())
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT CountryCode, FlagPath FROM Countries WHERE FlagPath IS NOT NULL AND FlagPath != ''", connection);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string countryCode = reader["CountryCode"].ToString();
                    string flagUrl = reader["FlagPath"].ToString();

                    // تحديد المسار الكامل للملف مع الاسم الصحيح (مثال: C:\MyProjectFlags\SY.svg)
                    string filePath = Path.Combine(DownloadFolderPath, $"{countryCode}.svg");

                    try
                    {
                        // تحميل العلم من الإنترنت
                        var flagData = await httpClient.GetByteArrayAsync(flagUrl);
                        // حفظ العلم في الملف
                        File.WriteAllBytes(filePath, flagData);
                        Console.WriteLine($"Successfully downloaded: {countryCode}.svg");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" -> Failed to download for {countryCode}: {ex.Message}");
                    }
                }
            }
        }
    }
}