using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixBannedUserEventType
    {
        [EnumMember(Value = "moderation.user.ban")]
        ModerationUserBan,

        [EnumMember(Value = "moderation.user.unban")]
        ModerationUserUnban
    }
}
