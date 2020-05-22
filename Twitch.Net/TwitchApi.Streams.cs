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

        private const string _getStreamsEndpoint = "https://api.twitch.tv/helix/streams";

        /// <summary>
        /// Get streams
        /// </summary>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        public async Task<HelixPaginatedResponse<HelixStream>> GetStreams(int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
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

            if (languages != null)
            {
                parameters.AddRange(languages.Select(language => new KeyValuePair<string, string>("language", language)));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixStream>>(responseStream);
        }

        /// <summary>
        /// Get streams for specific games
        /// </summary>
        /// <param name="gameIds">Array of game ids. Limit: 10</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithGameIds(string[] gameIds, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            parameters.AddRange(gameIds.Select(gameId => new KeyValuePair<string, string>("game_id", gameId)));

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (languages != null)
            {
                parameters.AddRange(languages.Select(language => new KeyValuePair<string, string>("language", language)));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixStream>>(responseStream);
        }

        /// <summary>
        /// Get streams for specific user ids
        /// </summary>
        /// <param name="userIds">Array of user ids. Limit: 100</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserIds(string[] userIds, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            parameters.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("user_id", userId)));

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (languages != null)
            {
                parameters.AddRange(languages.Select(language => new KeyValuePair<string, string>("language", language)));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixStream>>(responseStream);
        }

        /// <summary>
        /// Get streams for specific user logins
        /// </summary>
        /// <param name="userLogins">Array of user logins. Limit: 100</param>
        /// <param name="first">Amount of streams. Limit: 100</param>
        /// <param name="languages">Stream language. Limit: 100</param>
        /// <param name="after">Cursor for pagination</param>
        /// <param name="before">Cursor for pagination</param>
        /// <returns><see cref="HelixPaginatedResponse{HelixStream}"/> with streams</returns>
        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserLogins(string[] userLogins, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            parameters.AddRange(userLogins.Select(userLogin => new KeyValuePair<string, string>("user_login", userLogin)));

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (languages != null)
            {
                parameters.AddRange(languages.Select(language => new KeyValuePair<string, string>("language", language)));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixStream>>(responseStream);
        }

    }
}
