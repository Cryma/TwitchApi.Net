using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixCheermoteTierImageType
    {

        [JsonPropertyName("1")]
        public string One { get; set; }

        [JsonPropertyName("1.5")]
        public string OnePointFive { get; set; }

        [JsonPropertyName("2")]
        public string Two { get; set; }

        [JsonPropertyName("3")]
        public string Three { get; set; }

        [JsonPropertyName("4")]
        public string Four { get; set; }

    }
}
