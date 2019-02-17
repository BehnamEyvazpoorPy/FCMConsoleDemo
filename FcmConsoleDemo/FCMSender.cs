using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FcmConsoleDemo
{
    class FCMSender
    {
        private readonly string _serverKey;
        private readonly string _senderId;
        private readonly string _fcmConsoleUrl = "https://fcm.googleapis.com/fcm/send";

        public FCMSender(string serverKey, string senderId)
        {
            _serverKey = serverKey;
            _senderId = senderId;
        }

        public async Task<string> Send(FCMMessage message)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",$"Key={_serverKey}");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sender_id",_senderId);

            var dataJson = JsonConvert.SerializeObject(message,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            var response = await httpClient.PostAsync(_fcmConsoleUrl, new StringContent(dataJson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

    }
}
