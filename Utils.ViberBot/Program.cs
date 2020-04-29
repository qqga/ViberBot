using CommandLine;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Utils.ViberBot.Properties;
using ViberBot;
using ViberBot.Model.Request;

namespace Utils.ViberBot
{
    public class Options
    {
        [Value(0, Required = true, HelpText = "Message text.")]
        public string Text { get; set; }

        [Option('s', "sender", Required = false, HelpText = "Sender name.")]
        public string Sender { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(SensMessage);
        }

        static void SensMessage(Options options)
        {
            ViberBotClient viberBotClient = new ViberBotClient(Settings.Default.ViberToken);
            string text = options.Text;
            string from = options.Sender ?? Settings.Default.ViberClientFrom;
            var message = new TextMessage(text, from, Settings.Default.ViberClientTo);
            HttpResponseMessage sendMessage = viberBotClient.SendMessage(message).Result;
            var stringResp = sendMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine(stringResp);
        }
    }
}
