using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixGameAnalytic
    {

        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        [JsonPropertyName("URL")]
        public string Url { get; set; }

        [JsonPropertyName("type")]
        public HelixAnalyticType Type { get; set; }

        [JsonPropertyName("date_range")]
        public HelixDateRange DateRange { get; set; }

    }
}
