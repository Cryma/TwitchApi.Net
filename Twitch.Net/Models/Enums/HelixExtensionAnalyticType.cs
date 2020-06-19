using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixExtensionAnalyticType
    {
        [EnumMember(Value = "overview_v1")]
        OverviewV1,

        [EnumMember(Value = "overview_v2")]
        OverviewV2
    }
}
