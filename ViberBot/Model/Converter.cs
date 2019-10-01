using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.Globalization;
using System.Linq;

namespace ViberBot.Model
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }


    //public static class Serialize
    //{
    //    public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    //}
}


