using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

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
    }
}