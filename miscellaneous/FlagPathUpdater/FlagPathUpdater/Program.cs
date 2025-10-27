using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting process to update relative flag paths in the database...");

        try
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            await UpdateFlagRelativePaths(connectionString);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\nProcess finished successfully!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static async Task UpdateFlagRelativePaths(string connectionString)
    {
        var countryCodes = new List<string>();
        int updatedRows = 0;

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            var selectCommand = new SqlCommand("SELECT CountryCode FROM Countries WHERE CountryCode IS NOT NULL AND CountryCode != ''", connection);
            using (var reader = await selectCommand.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    countryCodes.Add(reader["CountryCode"].ToString().Trim());
                }
            }

            Console.WriteLine($"Found {countryCodes.Count} countries to update.");

            foreach (string code in countryCodes)
            {
                // *** التعديل الوحيد والمهم هنا ***
                // بناء المسار النسبي المطلوب. مثال: "\Resources\FlagsIcons\SY.svg"
                // نستخدم \\ بدلاً من \ لأن \ حرف خاص في C#
                string newRelativePath = $"Resources\\FlagsIcons\\{code}.png";

                var updateCommand = new SqlCommand("UPDATE Countries SET FlagPath = @NewPath WHERE CountryCode = @Code", connection);
                updateCommand.Parameters.AddWithValue("@NewPath", newRelativePath);
                updateCommand.Parameters.AddWithValue("@Code", code);

                int result = await updateCommand.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    updatedRows++;
                    Console.WriteLine($" - Updated path for {code} to '{newRelativePath}'");
                }
            }
        }

        Console.WriteLine($"\nUpdate complete. Total records updated: {updatedRows}");
    }
}