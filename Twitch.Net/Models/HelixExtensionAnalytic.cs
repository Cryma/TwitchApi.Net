using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixExtensionAnalytic
    {

        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }

        [JsonPropertyName("URL")]
        public string Url { get; set; }

        [JsonPropertyName("type")]
        public HelixExtensionAnalyticType Type { get; set; }

        [JsonPropertyName("date_range")]
        public HelixDateRange DateRange { get; set; }

    }
}
