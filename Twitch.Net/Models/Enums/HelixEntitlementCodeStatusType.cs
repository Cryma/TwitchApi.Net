using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum HelixEntitlementCodeStatusType
    {
        [EnumMember(Value = "INTERNAL_ERROR")]
        InternalError,

        [EnumMember(Value = "SUCCESSFULLY_REDEEMED")]
        SuccessfullyRedeemed,

        [EnumMember(Value = "ALREADY_CLAIMED")]
        AlreadyClaimed,

        [EnumMember(Value = "EXPIRED")]
        Expired,

        [EnumMember(Value = "USER_NOT_ELIGIBLE")]
        UserNotEligible,

        [EnumMember(Value = "NOT_FOUND")]
        NotFound,

        [EnumMember(Value = "INACTIVE")]
        Inactive,

        [EnumMember(Value = "UNUSED")]
        Unused,

        [EnumMember(Value = "INCORRECT_FORMAT")]
        IncorrectFormat
    }
}
