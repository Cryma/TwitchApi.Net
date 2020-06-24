using System;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixCreatedStreamMarker
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("position_seconds")]
        public int PositionSeconds { get; set; }

    }
}
