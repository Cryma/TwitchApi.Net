using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    /// <summary>
    /// Helix broadcaster type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixBroadcasterType
    {
        /// <summary>
        /// Broadcaster has no special type
        /// </summary>
        [EnumMember(Value = "")]
        None,

        /// <summary>
        /// Broadcaster is affiliate
        /// </summary>
        [EnumMember(Value = "affiliate")]
        Affiliate,

        /// <summary>
        /// Broadcaster is partner
        /// </summary>
        [EnumMember(Value = "partner")]
        Partner
    }
}
