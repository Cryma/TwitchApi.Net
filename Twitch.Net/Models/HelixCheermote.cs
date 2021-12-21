using System;
using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models
{
    public class HelixCheermote
    {

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("tiers")]
        public HelixCheermoteTier[] Tiers { get; set; }

        [JsonPropertyName("type")]
        public HelixCheermoteType Type { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("is_charitable")]
        public bool IsCharitable { get; set; }

    }
}
