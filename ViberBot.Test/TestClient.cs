using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ViberBot.Model.Request;

namespace ViberBot.Test
{
    public class TestClient
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Not for test")]
        public async Task SetWebhook()
        {
            ViberBotClient viberBotClient = new ViberBotClient("");
            HttpResponseMessage setWebhook = await viberBotClient.SetWebhook(new Model.RequestModel.Webhook(new System.Uri("")));

            string result = await setWebhook.Content.ReadAsStringAsync();
        }

        [Test]
        [Ignore("Not for test")]
        public async Task SendMsg()
        {
            ViberBotClient viberBotClient = new ViberBotClient("");
            HttpResponseMessage setWebhook = await viberBotClient.SendMessage(new TextMessage("test  log event reloaded 3", "TestProject", ""));

            string result = await setWebhook.Content.ReadAsStringAsync();
            viberBotClient.Dispose();
            TestContext.WriteLine(result);
        }

        [Test]
        [Ignore("Not for test")]
        public async Task SendMsgWebApi()
        {
            ViberWebApiNotifyer viberWebApiNotifyer = new ViberWebApiNotifyer("https://", "", "TestProjectWebApi", "");
            Task<HttpResponseMessage> sendMsg = viberWebApiNotifyer.SendMsg("test event");
            HttpResponseMessage httpResponseMessage = await sendMsg;
            string result = await httpResponseMessage.Content.ReadAsStringAsync();
            TestContext.WriteLine(result);
        }

    }
}