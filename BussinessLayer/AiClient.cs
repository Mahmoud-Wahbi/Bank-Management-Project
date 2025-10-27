using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business
{
    public class AiClient
    {
        private readonly HttpClient _http;
        private readonly string _apiKey = "AIzaSyC9F2ALrNXnd9SZ8tpLQDgjKJ14xnVOIsU";

        private readonly HashSet<string> _cryptoSymbols = new HashSet<string> { "BTC", "ETH", "XRP", "LTC", "BCH", "ADA", "DOT", "LINK", "BNB", "USDT", "SOL" };

        public AiClient()
        {
            _http = new HttpClient();
            // Add a User-Agent to avoid being blocked by some services
            _http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        }

        public async Task<AiResponse> AskAsync(string prompt)
        {
            // The existing prompt and Gemini API call logic remains unchanged
            var fullPrompt = @"
أنت مساعد مالي خبير. مهمتك هي تحليل استعلامات المستخدم والإجابة دائماً بصيغة JSON.
استخدم تنسيق Markdown (مثل **للنص العريض** و - للقوائم) لجعل الردود المعقدة سهلة القراءة.
التزم بالقواعد التالية بدقة:

1.  **إذا كان السؤال عن سعر صرف عملة (عادية أو مشفرة)**, يجب أن تكون النية 'get_currency_rate'. استخرج رموز العملات القياسية (ISO 4217 للعملات العادية, والرموز الشائعة مثل BTC, ETH للعملات المشفرة).
    - مثال 1: ""كم سعر الدولار مقابل الليرة التركية؟"" -> {""intent"":""get_currency_rate"",""parameters"":{""from_currency"":""USD"",""to_currency"":""TRY""}}
    - مثال 2: ""كم سعر البيتكوين بالدولار اليوم؟"" -> {""intent"":""get_currency_rate"",""parameters"":{""from_currency"":""BTC"",""to_currency"":""USD""}}

2.  **إذا كان السؤال سؤالاً عاماً عن البنوك أو العملات أو الاقتصاد** (مثل: ما هو التضخم؟, كيف تعمل البنوك؟), يجب أن تكون النية 'general_knowledge' وأن تقدم إجابة وافية في حقل الرد.
    - مثال: ""ما هو رمز سويفت؟"" -> {""intent"":""general_knowledge"",""reply"":""رمز سويفت (SWIFT Code) هو رمز تعريفي فريد للبنك يستخدم في التحويلات الدولية لضمان وصول الأموال إلى البنك الصحيح.""}

3.  **إذا كان السؤال يتعلق بخدمة بنكية محددة** (مثل الرصيد, التحويل), استخدم النوايا المخصصة مثل 'check_balance', 'transfer_funds' إلخ.
    - مثال: ""ما هو رصيدي؟"" -> {""intent"":""check_balance"",""parameters"":{},""reply"":""يمكنك التحقق من رصيدك عبر تطبيق البنك.""}

4.  **إذا كان السؤال خارج النطاق المالي تماماً** (مثل الطقس, الرياضة), اجعل النية 'out_of_scope' مع رسالة اعتذار.
    - مثال: ""ما هي نتيجة مباراة الأمس؟"" -> {""intent"":""out_of_scope"",""reply"":""عفواً, أنا متخصص فقط في الأمور المالية والمصرفية.""}

السؤال هو: " + prompt;

            var body = new
            {
                contents = new[] { new { parts = new[] { new { text = fullPrompt } } } }
            };

            string json = JsonConvert.SerializeObject(body);
            var requestUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro-latest:generateContent?key=" + _apiKey;
            var response = await _http.PostAsync(requestUrl, new StringContent(json, Encoding.UTF8, "application/json"));
            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Error ({response.StatusCode}): {responseText}");

            var obj = JObject.Parse(responseText);
            var aiText = (string)obj["candidates"]?[0]?["content"]?["parts"]?[0]?["text"];

            if (string.IsNullOrWhiteSpace(aiText))
                return new AiResponse { Reply = "لم يتم الحصول على رد من AI" };

            var aiResponse = AiResponse.FromJson(aiText);

            if (aiResponse.Intent == "get_currency_rate")
            {
                aiResponse.Parameters.TryGetValue("from_currency", out object fromObj);
                aiResponse.Parameters.TryGetValue("to_currency", out object toObj);

                if (fromObj != null && toObj != null)
                {
                    string fromCurrency = fromObj.ToString().ToUpper();
                    string toCurrency = toObj.ToString().ToUpper();

                    try
                    {
                        if (_cryptoSymbols.Contains(fromCurrency) || _cryptoSymbols.Contains(toCurrency))
                        {
                            decimal rate = await GetRealTimeCryptoRate(fromCurrency, toCurrency);
                            aiResponse.Reply = $"السعر الحالي لـ {fromCurrency} مقابل {toCurrency} هو: {rate:N2}";
                        }
                        else
                        {
                            // *** This is the change: calling the new and improved function ***
                            decimal rate = await GetRealTimeFiatRate_Improved(fromCurrency, toCurrency);
                            aiResponse.Reply = $"**السعر التقريبي في السوق** لـ {fromCurrency} مقابل {toCurrency} هو: **{rate:N0}**";
                        }
                    }
                    catch (Exception ex)
                    {
                        aiResponse.Reply = $"عذراً، حدث خطأ: {ex.Message}";
                    }
                }
                else
                {
                    aiResponse.Reply = "لم أستطع تحديد العملات المطلوبة.";
                }
            }

            return aiResponse;
        }

        /// <summary>
        /// *** New and improved function to fetch fiat currency rates ***
        /// Relies on a different and more realistic data source.
        /// </summary>
        private async Task<decimal> GetRealTimeFiatRate_Improved(string from, string to)
        {
            // We use a service that provides rates closer to the market value
            var apiUrl = $"https://api.exchangerate-api.com/v4/latest/{from}";
            var response = await _http.GetStringAsync(apiUrl);
            var data = JObject.Parse(response);

            if (data["result"]?.ToString() == "error")
            {
                throw new Exception($"العملة '{from}' غير مدعومة أو غير صالحة.");
            }

            var rate = data["rates"]?[to];
            if (rate == null)
            {
                throw new Exception($"لم يتم العثور على سعر صرف للعملة '{to}'.");
            }

            return rate.Value<decimal>();
        }

        private async Task<decimal> GetRealTimeCryptoRate(string from, string to)
        {
            string cryptoId = _cryptoSymbols.Contains(from) ? from : to;
            string fiatId = _cryptoSymbols.Contains(from) ? to : from;

            var idMap = new Dictionary<string, string> { { "BTC", "bitcoin" }, { "ETH", "ethereum" } };
            if (!idMap.ContainsKey(cryptoId)) throw new Exception($"العملة المشفرة {cryptoId} غير مدعومة حالياً.");

            string coinGeckoId = idMap[cryptoId];
            var apiUrl = $"https://api.coingecko.com/api/v3/simple/price?ids={coinGeckoId}&vs_currencies={fiatId.ToLower()}";
            var response = await _http.GetStringAsync(apiUrl);
            var data = JObject.Parse(response);

            var rate = data[coinGeckoId]?[fiatId.ToLower()];
            if (rate == null) throw new Exception("لم أتمكن من جلب السعر من خدمة CoinGecko.");

            if (cryptoId == to)
            {
                return 1 / rate.Value<decimal>();
            }

            return rate.Value<decimal>();
        }
    }
}