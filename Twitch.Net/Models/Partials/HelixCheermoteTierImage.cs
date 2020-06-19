using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixCheermoteTierImage
    {

        [JsonPropertyName("dark")]
        public HelixCheermoteTierImageTheme Dark { get; set; }

        [JsonPropertyName("light")]
        public HelixCheermoteTierImageTheme Light { get; set; }

    }
}
