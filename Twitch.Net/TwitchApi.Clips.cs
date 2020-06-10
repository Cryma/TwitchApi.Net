using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Twitch.Net.Models;
using Twitch.Net.Response;
using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private const string _getClipsEndpoint = "https://api.twitch.tv/helix/clips";

        /// <summary>
        /// Get clips from clip ids
        /// </summary>
        /// <param name="clipIds">Array of clip ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{HelixClip}"/> with clips</returns>
        public async Task<HelixResponse<HelixClip>> GetClips(string[] clipIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(clipIds.Select(clipId => new KeyValuePair<string, string>("id", clipId)));

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixClip>>(responseStream);
        }

        /// <summary>
        /// Get clips of specific games
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="first">Amount of clips. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixClips}"/> with clips</returns>
        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromGames(string gameId, int first = 20, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("game_id", gameId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

        /// <summary>
        /// Get clips from specific broadcaster
        /// </summary>
        /// <param name="broadcasterId">Broadcaster id</param>
        /// <param name="first">Amount of clips. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <param name="startedAt">Starting date/time for returned clips. If this is specified, ended_at also should be specified; otherwise, the ended_at date/time will be 1 week after the started_at value.</param>
        /// <param name="endedAt">Ending date/time for returned clips.) If this is specified, started_at also must be specified; otherwise, the time period is ignored.</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixClips}"/> with clips</returns>
        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromBroadcaster(string broadcasterId, int first = 20, string after = null, string before = null, DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (startedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("started_at", HttpUtility.UrlEncode(startedAt.Value.ToRfc3339String())));
            }
            
            if (endedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("ended_at", HttpUtility.UrlEncode(endedAt.Value.ToRfc3339String())));
            }

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

    }
}
