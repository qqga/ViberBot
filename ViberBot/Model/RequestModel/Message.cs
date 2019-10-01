using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViberBot.Model.Request
{
    public class TextMessage : Message
    {
        public TextMessage(string text, string sender, string receiver, Uri senderAvatar = null) : base(text, sender, receiver, senderAvatar)
        {

        }

        public override MessageType Type => MessageType.text;
    }

    public enum MessageType
    {
        text,
        //todo: implement other types 
        picture,
        video,
        file,
        contact,
        location,
        url,
        sticker,
        rich_media,
        keyboard

    }
    public abstract partial class Message
    {
        public Message(string text, string sender, string receiver, Uri senderAvatar = null)
        {
            Receiver = receiver;
            Sender = new Sender() { Name = sender, Avatar = senderAvatar };
            Text = text;
        }


        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("min_api_version")]
        public long MinApiVersion { get; set; } 

        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [JsonProperty("tracking_data")]
        public string TrackingData { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract MessageType Type { get; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Sender
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }
    }

    public partial class Message
    {
        public static Message FromJson(string json) => JsonConvert.DeserializeObject<Message>(json, Converter.Settings);
    }



}
