using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;

namespace Twitch.Net.Models
{
    public class HelixEntitlementCode
    {

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("status")]
        public HelixEntitlementCodeStatusType Status { get; set; }

    }
}
