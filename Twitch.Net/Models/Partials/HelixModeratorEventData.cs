using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixModeratorEventData
    {

        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

    }
}
