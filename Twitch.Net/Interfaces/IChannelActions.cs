using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IChannelActions
    {

        Task<HelixResponse<HelixChannelInformation>> GetChannelInformation(string userId);

        Task ModifyChannelInformation(string userId, string status = null, string gameId = null, string broadcasterLanguage = null,
            string title = null, string description = null);

    }
}
