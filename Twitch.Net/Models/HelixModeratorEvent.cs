using System;
using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixModeratorEvent
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("event_type")]
        public HelixModeratorEventType EventType { get; set; }

        [JsonPropertyName("event_timestamp")]
        public DateTime EventTimestamp { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("event_data")]
        public HelixModeratorEventData EventData { get; set; }

    }
}
