using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class UndocumentedPanelData
    {

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

    }
}
