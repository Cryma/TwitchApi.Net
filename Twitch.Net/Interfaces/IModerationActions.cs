using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IModerationActions
    {

        Task<HelixPaginatedResponse<HelixBannedUser>> GetBannedUsers(string broadcasterId, string[] userIds = null, string after = null, string before = null);

    }
}
