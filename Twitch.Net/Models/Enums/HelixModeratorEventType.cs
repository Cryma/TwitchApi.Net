using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]

    public enum HelixModeratorEventType
    {
        [EnumMember(Value = "moderation.moderator.remove")]
        ModerationModeratorRemove,

        [EnumMember(Value = "moderation.moderator.add")]
        ModerationModeratorAdd
    }
}
