using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class UndocumentedPanel
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("display_order")]
        public int DisplayOrder { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("data")]
        public UndocumentedPanelData Data { get; set; }

        [JsonPropertyName("html_description")]
        public string HtmlDescription { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

    }
}
