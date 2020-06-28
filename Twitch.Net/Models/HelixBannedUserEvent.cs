using System;
using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixBannedUserEvent
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("event_type")]
        public HelixBannedUserEventType EventType { get; set; }

        [JsonPropertyName("event_timestamp")]
        public DateTime EventTimestamp { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("event_data")]
        public HelixBannedUserEventData EventData { get; set; }

    }
}
