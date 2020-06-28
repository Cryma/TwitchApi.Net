using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixStreamKey
    {

        [JsonPropertyName("stream_key")]
        public string StreamKey { get; set; }

    }
}
