using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Pokedex
{
    public partial class Pokemon
    {
        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("types")]
        public Types[] Types { get; set; }

        [JsonProperty("moves")]
        public Moves[] Moves { get; set; }

        [JsonProperty("stats")]
        public Stats[] Stats { get; set; }

    }

    public partial class Sprites
    {
        [JsonProperty("front_default")]
        public string Front_default { get; set; }
    }

    public partial class Types
    {
        [JsonProperty("type")]
        public Type Type { get; set; }
    }
    public partial class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Moves
    {
        [JsonProperty("move")]
        public Move Move { get; set; }
    }

    public partial class Move
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public partial class Stats
    {
        [JsonProperty("base_stat")]
        public string Base_stat { get; set; }
    }


    public partial class Pokemon
    {
        public static Pokemon FromJson(string json) => JsonConvert.DeserializeObject<Pokemon>(json, Pokedex.Converter.Settings);
    }

    public static class Serializar
    {
        public static string ToJson(this Pokemon self) => JsonConvert.SerializeObject(self, Pokedex.Converter.Settings);
    }

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

    }
}
