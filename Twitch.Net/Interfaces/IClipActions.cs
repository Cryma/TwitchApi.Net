using System;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;

namespace Twitch.Net.Interfaces
{
    public interface IClipActions
    {

        /// <summary>
        /// Get clips from clip ids
        /// </summary>
        /// <param name="clipIds">Array of clip ids. Limit: 100</param>
        /// <param name="first">Amount of clips. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="startedAt">Starting date/time for returned clips. If this is specified, ended_at also should be specified; otherwise, the ended_at date/time will be 1 week after the started_at value.</param>
        /// <param name="endedAt">Ending date/time for returned clips.) If this is specified, started_at also must be specified; otherwise, the time period is ignored.</param>
        /// <returns><see cref="HelixResponse{TResponseObject}"/> with clips</returns>
        Task<HelixResponse<HelixClip>> GetClipsFromIds(string[] clipIds, int first = 20, string after = null, string before = null, DateTime? startedAt = null,
            DateTime? endedAt = null);

        /// <summary>
        /// Get clips of specific games
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="first">Amount of clips. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="startedAt">Starting date/time for returned clips. If this is specified, ended_at also should be specified; otherwise, the ended_at date/time will be 1 week after the started_at value.</param>
        /// <param name="endedAt">Ending date/time for returned clips.) If this is specified, started_at also must be specified; otherwise, the time period is ignored.</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with clips</returns>
        Task<HelixPaginatedResponse<HelixClip>> GetClipsFromGames(string gameId, int first = 20, string after = null, string before = null, DateTime? startedAt = null,
            DateTime? endedAt = null);

        /// <summary>
        /// Get clips from specific broadcaster
        /// </summary>
        /// <param name="broadcasterId">Broadcaster id</param>
        /// <param name="first">Amount of clips. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="startedAt">Starting date/time for returned clips. If this is specified, ended_at also should be specified; otherwise, the ended_at date/time will be 1 week after the started_at value.</param>
        /// <param name="endedAt">Ending date/time for returned clips.) If this is specified, started_at also must be specified; otherwise, the time period is ignored.</param>
        /// <returns><see cref="HelixPaginatedResponse{TResponseObject}"/> with clips</returns>
        Task<HelixPaginatedResponse<HelixClip>> GetClipsFromBroadcaster(string broadcasterId, int first = 20, string after = null, string before = null,
            DateTime? startedAt = null, DateTime? endedAt = null);

    }
}
