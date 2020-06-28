using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixStreamMarkerVideo
    {

        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }

        [JsonPropertyName("markers")]
        public HelixStreamMarkerEntry[] Markers { get; set; }

    }
}
