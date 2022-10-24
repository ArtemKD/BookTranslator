using Polly;
using Polly.Retry;
using Polly.Timeout;

namespace YandexCloud
{
    static class RetryPolicy
    {
        public static AsyncRetryPolicy<HttpResponseMessage> policy = Policy
            .Handle<HttpRequestException>()
            .OrResult<HttpResponseMessage>(r => (int)r.StatusCode == 404 || (int)r.StatusCode == 503)
            .WaitAndRetryAsync(retryCount: 20, sleepDurationProvider: _ => TimeSpan.FromSeconds(2));
    }
}
