using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixCheermoteTierImageTheme
    {

        [JsonPropertyName("animated")]
        public HelixCheermoteTierImageType Animated { get; set; }

        [JsonPropertyName("static")]
        public HelixCheermoteTierImageType Static { get; set; }

    }
}
