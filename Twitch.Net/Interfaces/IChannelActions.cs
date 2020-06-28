using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IChannelActions
    {

        Task<HelixResponse<HelixChannelInformation>> GetChannelInformation(string userId);

    }
}
