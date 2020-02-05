using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Response;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        public const string _getVideosEndpoint = "https://api.twitch.tv/helix/videos";

        /// <summary>
        /// Get videos for video ids
        /// </summary>
        /// <param name="videoIds">Array of video ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{HelixVideo}"/> with videos</returns>
        public async Task<HelixResponse<HelixVideo>> GetVideos(string[] videoIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(videoIds.Select(videoId => new KeyValuePair<string, string>("id", videoId)));

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixVideo>>(responseStream);
        }

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
        /// <returns><see cref="HelixPaginatedResponse{HelixVideo}"/> with games</returns>
        public async Task<HelixPaginatedResponse<HelixVideo>> GetVideosFromGame(string gameId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null)
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

            if (string.IsNullOrEmpty(language) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("language", language));
            }

            if (string.IsNullOrEmpty(period) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("period", period));
            }

            if (string.IsNullOrEmpty(sort) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("sort", sort));
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("type", type));
            }

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixVideo>>(responseStream);
        }

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
        /// <returns><see cref="HelixPaginatedResponse{HelixVideo}"/> with games</returns>
        public async Task<HelixPaginatedResponse<HelixVideo>> GetVideosFromUser(string userId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId),
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

            if (string.IsNullOrEmpty(language) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("language", language));
            }

            if (string.IsNullOrEmpty(period) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("period", period));
            }

            if (string.IsNullOrEmpty(sort) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("sort", sort));
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("type", type));
            }

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixVideo>>(responseStream);
        }

    }
}
