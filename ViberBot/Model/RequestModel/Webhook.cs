using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViberBot.Model.RequestModel
{


    public partial class Webhook
    {
        public Webhook(Uri url)
        {
            Url = url;
        }

        /// <summary>
        /// SSL required.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Leave it empty for all types.
        /// </summary>
        [JsonProperty("event_types")]
        public string[] EventTypes { get; set; }

        [JsonProperty("send_name")]
        public bool SendName { get; set; } = true;

        [JsonProperty("send_photo")]
        public bool SendPhoto { get; set; }

        public static string[] EventTypesAvalible = new[] { "delivered", "seen", "failed", "subscribed", "unsubscribed", "conversation_started" };
    }

    //public partial class Welcome
    //{
    //    public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    //}

}
