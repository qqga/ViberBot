using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViberBot.Model.Request;
using ViberBot.Model;
using ViberBot.Model.Response;
using ViberBot.Model.RequestModel;

namespace ViberBot
{
    public class ViberBotClient : IDisposable
    {
        string _token;
        public string UrlMsg { get; set; } = Resource.UrlMsg;
        public string UrlAccountInfo { get; set; } = Resource.UrlAccountInfo;
        public string URlWebhook { get; set; } = Resource.UrlWebhook;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string TokenHeaderKeyName { get; set; }



        HttpClient _httpClient;
        public ViberBotClient(string token, string tokenHeaderKeyName = null)
        {
            TokenHeaderKeyName = tokenHeaderKeyName ?? Resource.TokenHeaderKeyName;
            _token = token;

            InitClient();
        }

        private void InitClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add(TokenHeaderKeyName, _token);
        }

        public async Task<AccountInfo> GetAccountInfo()
        {
            HttpResponseMessage postAsync = await _httpClient.PostAsync(UrlAccountInfo, EncodeMsg("{}"));
            string content = await postAsync.Content.ReadAsStringAsync();
            AccountInfo accountInfo = AccountInfo.FromJson(content);
            return accountInfo;
        }

        public Task<HttpResponseMessage> SendMessage(Message msg)
        {
            string jsonMsg = msg.ToJson();
            ByteArrayContent byteArrayContent = EncodeMsg(jsonMsg);
            return _httpClient.PostAsync(UrlMsg, byteArrayContent);
        }

        ByteArrayContent EncodeMsg(string msg) => new ByteArrayContent(this.Encoding.GetBytes(msg));

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public Task<HttpResponseMessage> SetWebhook(Webhook webhook)
        {
            string jsonMsg = webhook.ToJson();
            Task<HttpResponseMessage> postAsync = _httpClient.PostAsync(URlWebhook, EncodeMsg(jsonMsg));
            return postAsync;
        }
    }
}
