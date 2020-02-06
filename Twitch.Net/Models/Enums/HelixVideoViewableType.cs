using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    /// <summary>
    /// Helix video viewable type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixVideoViewableType
    {
        /// <summary>
        /// Video is public
        /// </summary>
        [EnumMember(Value = "public")]
        Public,

        /// <summary>
        /// Video is private
        /// </summary>
        [EnumMember(Value = "private")]
        Private,
    }
}
