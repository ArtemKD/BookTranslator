using System.Net.Http.Json;
using System.Text.Json;

namespace YandexCloud
{
    static class IamToken
    {
        public static async Task<Reply> Get(String oAuth, CancellationToken ct)
        {
            String iamToken = String.Empty;
            String iamHost = "iam.api.cloud.yandex.net";
            String iamTarget = "/iam/v1/tokens";
            Uri iamUri = new Uri("https://" + iamHost + iamTarget);
            HttpClient iamConnection = new HttpClient();

            var data = new Dictionary<String, String>()
            {
                {"yandexPassportOauthToken", oAuth }
            };

            JsonDocument? requestJsonData;
            JsonDocument? responceJsonData;
            HttpResponseMessage? responce = null;

            try
            {
                requestJsonData = JsonSerializer.SerializeToDocument<Dictionary<String, String>>(data);
                responce = await iamConnection.PostAsJsonAsync<JsonDocument>(iamUri, requestJsonData, ct);
                responceJsonData = await responce.Content.ReadFromJsonAsync<JsonDocument>();
            }
            catch (HttpRequestException requestEx)
            {
                return new Reply
                {
                    Code = requestEx.HResult,
                    Message = "Ошибка сети, проверьте соединение и повторите попытку"
                };
            }
            catch (TaskCanceledException cancelEx)
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
                    Message = ex.Message
                };
            }
            if (responce.IsSuccessStatusCode)
            {
                return new Reply
                {
                    Code = (int)responce.StatusCode,
                    Message = responceJsonData != null ?
                    responceJsonData.RootElement.GetProperty("iamToken").ToString() :
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
