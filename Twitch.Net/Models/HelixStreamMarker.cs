using System.Text.Json.Serialization;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixStreamMarker
    {

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("videos")]
        public HelixStreamMarkerVideo[] Videos { get; set; }

    }
}
