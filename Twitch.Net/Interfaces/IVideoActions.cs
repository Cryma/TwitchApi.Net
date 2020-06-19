using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IVideoActions
    {

        /// <summary>
        /// Get videos for video ids
        /// </summary>
        /// <param name="videoIds">Array of video ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with videos</returns>
        Task<HelixResponse<HelixVideo>> GetVideos(string[] videoIds);

        /// <summary>
        /// Get videos for specific game with optional filters
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="first">Amount of videos. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="language">Video language</param>
        /// <param name="period">Video period. Either "all" (default), "day", "week", "month"</param>
        /// <param name="sort">Video sort order. Either "time" (default), "trending", "views"</param>
        /// <param name="type">Video type. Either "all" (default), "upload", "archive", "highlight"</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with games</returns>
        Task<HelixPaginatedResponse<HelixVideo>> GetVideosFromGame(string gameId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null);

        /// <summary>
        /// Get videos from specific user with optional filters
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="first">Amount of videos. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="language">Video language</param>
        /// <param name="period">Video period. Either "all" (default), "day", "week", "month"</param>
        /// <param name="sort">Video sort order. Either "time" (default), "trending", "views"</param>
        /// <param name="type">Video type. Either "all" (default), "upload", "archive", "highlight"</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with games</returns>
        Task<HelixPaginatedResponse<HelixVideo>> GetVideosFromUser(string userId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null);

    }
}
