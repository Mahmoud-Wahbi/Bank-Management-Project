using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Business
{
    public class AiClientHelper
    {
        private readonly string _apiKey = "AIzaSyAmX89NKlVTFi5WoG8N3-gvFor0Ojppq3c";

        public async Task<string> GetAvailableModelsAsync()
        {
            using (var http = new HttpClient())
            {
                var url = $"https://generativelanguage.googleapis.com/v1beta/models?key={_apiKey}";
                var resp = await http.GetAsync(url);
                string content = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    throw new Exception($"API Error ({resp.StatusCode}): {content}");

                return content;
            }
        }
    }
}
