using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    /// <summary>
    /// Helix commercial length type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixCommercialLength
    {
        /// <summary>
        /// 30 seconds
        /// </summary>
        ThirtySeconds,

        /// <summary>
        /// 60 seconds
        /// </summary>
        SixtySeconds,

        /// <summary>
        /// 90 seconds
        /// </summary>
        NinetySeconds,

        /// <summary>
        /// 120 seconds
        /// </summary>
        OneHundredAndTwentySeconds,

        /// <summary>
        /// 150 seconds
        /// </summary>
        OneHundredAndFiftySeconds,

        /// <summary>
        /// 180 seconds
        /// </summary>
        OneHundredAndEightySeconds
    }
}
