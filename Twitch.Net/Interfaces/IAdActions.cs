using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IAdActions
    {

        /// <summary>
        /// Start a commercial on a specified channel
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="length">Commercial length</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with commercial info</returns>
        Task<HelixResponse<HelixCommercial>> StartCommercial(string userId, HelixCommercialLength length);

    }
}
