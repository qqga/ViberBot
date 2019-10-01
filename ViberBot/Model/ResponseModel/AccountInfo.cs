using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ViberBot.Model.Response
{
    public partial class AccountInfo
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("chat_hostname")]
        public string ChatHostname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("members")]
        public Member[] Members { get; set; }

        [JsonProperty("subscribers_count")]
        public long SubscribersCount { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public partial class AccountInfo
    {
        public static AccountInfo FromJson(string json) => JsonConvert.DeserializeObject<AccountInfo>(json, Converter.Settings);
    }
}


