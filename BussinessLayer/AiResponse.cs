using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Business
{
    public class AiResponse
    {
        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();

        [JsonProperty("reply")]
        public string Reply { get; set; }

        public static AiResponse FromJson(string json)
        {
            try
            {
                // Remove any Markdown markers the model might add to the JSON
                var cleanedJson = json.Trim().Replace("```json", "").Replace("```", "");
                return JsonConvert.DeserializeObject<AiResponse>(cleanedJson);
            }
            catch
            {
                return new AiResponse
                {
                    Intent = "unknown",
                    Parameters = new Dictionary<string, object>(),
                    // Fallback: if not valid JSON, return the text itself
                    Reply = json
                };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}