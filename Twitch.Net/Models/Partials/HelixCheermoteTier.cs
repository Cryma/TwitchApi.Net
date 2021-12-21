using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Partials
{
    public class HelixCheermoteTier
    {

        [JsonPropertyName("min_bits")]
        public int MinBits { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("images")]
        public HelixCheermoteTierImage Images { get; set; }

        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }

        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }

    }
}
