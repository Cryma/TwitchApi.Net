using System;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixDateRange
    {

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; set; }

    }
}
