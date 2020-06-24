using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IStreamActions
    {

        /// <summary>
        /// Get streams
        /// </summary>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with streams</returns>
        Task<HelixPaginatedResponse<HelixStream>> GetStreams(int first = 20, string[] languages = null, string after = null, string before = null);

        /// <summary>
        /// Get streams for specific games
        /// </summary>
        /// <param name="gameIds">Array of game ids. Limit: 10</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithGameIds(string[] gameIds, int first = 20, string[] languages = null, string after = null, string before = null);

        /// <summary>
        /// Get streams for specific user ids
        /// </summary>
        /// <param name="userIds">Array of user ids. Limit: 100</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserIds(string[] userIds, int first = 20, string[] languages = null, string after = null, string before = null);

        /// <summary>
        /// Get streams for specific user logins
        /// </summary>
        /// <param name="userLogins">Array of user logins. Limit: 100</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserLogins(string[] userLogins, int first = 20, string[] languages = null, string after = null, string before = null);

        Task<HelixResponse<HelixStreamKey>> GetStreamKey(string broadcasterId);

        Task<HelixResponse<HelixCreatedStreamMarker>> CreateStreamMarker(string userId, string description = null);

    }
}
