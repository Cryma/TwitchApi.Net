using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    /// <summary>
    /// Helix user type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixUserType
    {
        /// <summary>
        /// Normal user
        /// </summary>
        [EnumMember(Value = "")]
        None,

        /// <summary>
        /// User is staff
        /// </summary>
        [EnumMember(Value = "staff")]
        Staff,

        /// <summary>
        /// User is admin
        ///
        /// <para>Note: This type does not exist anymore</para>
        /// </summary>
        [EnumMember(Value = "admin")]
        Admin,

        /// <summary>
        /// User is global moderator
        ///
        /// <para>Note: This type does not exist anymore</para>
        /// </summary>
        [EnumMember(Value = "global_mod")]
        GlobalModerator
    }
}
