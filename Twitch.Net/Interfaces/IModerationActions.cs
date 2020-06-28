using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IModerationActions
    {

        Task<HelixPaginatedResponse<HelixBannedUser>> GetBannedUsers(string broadcasterId, string[] userIds = null, string after = null, string before = null);

        Task<HelixPaginatedResponse<HelixBannedUserEvent>> GetBannedEvents(string broadcasterId, string[] userIds = null, string after = null, string before = null);

        Task<HelixPaginatedResponse<HelixModerator>> GetModerators(string broadcasterId, string[] userIds = null, string after = null, string before = null);

        Task<HelixPaginatedResponse<HelixModeratorEvent>> GetModeratorEvents(string broadcasterId, string[] userIds = null, string after = null, string before = null);

    }
}
