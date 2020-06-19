using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IUserActions
    {

        /// <summary>
        /// Get users from user ids
        /// </summary>
        /// <param name="userIds">Array of user ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with users</returns>
        Task<HelixResponse<HelixUser>> GetUsersWithIds(string[] userIds);

        /// <summary>
        /// Get users from user login names
        /// </summary>
        /// <param name="userLoginNames">Array of user login names. Limit: 100</param>
        /// <returns><see cref="HelixResponse{HelixUser}"/> with users</returns>
        Task<HelixResponse<HelixUser>> GetUsersWithLoginNames(string[] userLoginNames);

        /// <summary>
        /// Either get user follows or followers
        ///
        /// <para>Either specify "toId" or "fromId" - not both</para>
        /// </summary>
        /// <param name="first">Amount. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="toId">User id you want the followers of</param>
        /// <param name="fromId">User id you want the follows of</param>
        /// <returns><see cref="HelixPaginatedResponseWithTotal{HelixFollow}"/> with follows</returns>
        Task<HelixPaginatedResponseWithTotal<HelixFollow>> GetUsersFollows(int first = 20, string after = null, string toId = null, string fromId = null);

    }
}
