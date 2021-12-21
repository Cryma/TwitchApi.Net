using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixEntitlementGrant
    {

        [JsonPropertyName("url")]
        public string Url { get; set; }

    }
}
