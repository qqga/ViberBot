using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ViberBot
{
    public class ViberWebApiNotifyer : IDisposable
    {
        readonly string _Token;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string Url { get; set; }
        HttpClient _httpClient = new HttpClient();
        public string From { get; set; }
        public string To { get; set; }
        public ViberWebApiNotifyer(string url, string token, string from, string to)
        {
            To = to;
            From = from;
            _Token = token;
            Url = url;
        }
        public Task<HttpResponseMessage> SendMsg(string msg, string from = null, string to = null)
        {
            MultipartFormDataContent byteArrayContent = new MultipartFormDataContent();
            byteArrayContent.Add(StringToHttpContent(from ?? From), "from");
            byteArrayContent.Add(StringToHttpContent(to ?? To), "to");
            byteArrayContent.Add(StringToHttpContent(msg), "msg");
            byteArrayContent.Add(StringToHttpContent(_Token), "token");

            return _httpClient.PostAsync(Url, byteArrayContent);
        }

        HttpContent StringToHttpContent(string str)
        {
            byte[] bytes = this.Encoding.GetBytes(str);
            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            return byteArrayContent;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
