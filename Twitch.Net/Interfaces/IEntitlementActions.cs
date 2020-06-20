using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IEntitlementActions
    {

        Task<HelixResponse<HelixEntitlementGrant>> CreateEntitlementGrantsUploadUrl(string manifestId, HelixEntitlementGrantType type);

        Task<HelixResponse<HelixEntitlementCode>> GetCodeStatus(string[] codes, string userId);

    }
}
