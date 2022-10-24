using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace YandexCloud
{
    internal class TranslatorYC
    {
        private String iamToken;
        private String translationHost;
        private String translationTarget;
        private Uri translationUri;
        private HttpClient translateConnection;

        private String folderId;

        public TranslatorYC(String iamToken)
        {
            this.iamToken = iamToken;

            this.translationHost = "translate.api.cloud.yandex.net";
            this.translationTarget = "/translate/v2/translate";
            this.translationUri = new Uri("https://" + this.translationHost + this.translationTarget);
            this.translateConnection = new HttpClient();
            this.translateConnection.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.iamToken);

            this.folderId = "b1ga1g0epv5ub27qagll";
        }

        public async Task<Reply> Translate(String text, String fromLang, String toLang, CancellationToken ct)
        {
            if (toLang == String.Empty)
            {
                return new Reply
                {
                    Code = -1,
                    Message = "Не выбран язык перевода"
                };
            }
            var data = new Dictionary<String, String>()
            {
                { "folderId", this.folderId },
                { "texts",  text },
                { "targetLanguageCode", toLang }
            };
            if (fromLang != String.Empty)
            {
                data.Add("sourceLanguageCode", fromLang);
            }

            JsonDocument? requestJsonData = null;
            JsonDocument? responceJsonData = null;
            HttpResponseMessage? responce = null;

            try
            {
                requestJsonData = JsonSerializer.SerializeToDocument<Dictionary<String, String>>(data);
                responce = await RetryPolicy.policy.ExecuteAsync(() => translateConnection.PostAsJsonAsync<JsonDocument>(translationUri, requestJsonData, ct));
                responce = await translateConnection.PostAsJsonAsync<JsonDocument>(translationUri, requestJsonData, ct);
                responceJsonData = await responce.Content.ReadFromJsonAsync<JsonDocument>();
            }
            catch(HttpRequestException requestEx)
            {
                return new Reply
                {
                    Code = requestEx.HResult,
                    Message = "Ошибка сети, проверьте соединение и повторите попытку"
                };
            }
            catch(TaskCanceledException cancelEx)
            {
                return new Reply
                {
                    Code = -11,
                    Message = "Отмена"
                };
            }
            catch (Exception ex)
            {
                return new Reply
                {
                    Code = ex.HResult,
                    Message = ex.ToString()
                };
            }

            if (responce.IsSuccessStatusCode)
            {

                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("translations").EnumerateArray().ToList()[0].GetProperty("text").ToString() :
                    "Empty responce data"
                };
            }
            else
            {
                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("message").ToString() :
                    "Empty responce data"
                };
            }
        }
    }

}
