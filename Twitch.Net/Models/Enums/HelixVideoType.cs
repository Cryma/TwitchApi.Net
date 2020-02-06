using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    /// <summary>
    /// Helix video type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixVideoType
    {
        /// <summary>
        /// Video was uploaded
        /// </summary>
        [EnumMember(Value = "upload")]
        Upload,

        /// <summary>
        /// Video was archived
        /// </summary>
        [EnumMember(Value = "archive")]
        Archive,

        /// <summary>
        /// Video is a highlight
        /// </summary>
        [EnumMember(Value = "highlight")]
        Highlight,
    }
}
