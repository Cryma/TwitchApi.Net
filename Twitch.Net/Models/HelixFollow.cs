using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixFollow
    {

        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        [JsonPropertyName("from_name")]
        public string FromName { get; set; }

        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        [JsonPropertyName("to_name")]
        public string ToName { get;set; }

        [JsonPropertyName("followed_at")]
        public string FollowedAt { get; set; }

    }
}
