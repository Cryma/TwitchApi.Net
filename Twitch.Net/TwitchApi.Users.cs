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

        private const string _getUsersEndpoint = "https://api.twitch.tv/helix/users";
        private const string _getUsersFollowsEndpoint = "https://api.twitch.tv/helix/users/follows";

        /// <summary>
        /// Get users from user ids
        /// </summary>
        /// <param name="userIds">Array of user ids. Limit: 100</param>
        /// <returns><see cref="HelixResponse{HelixUser}"/> with users</returns>
        public async Task<HelixResponse<HelixUser>> GetUsers(string[] userIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("id", userId)));

            var responseStream = await httpClient.GetAsync(_getUsersEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixUser>>(responseStream);
        }

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
        public async Task<HelixPaginatedResponseWithTotal<HelixFollow>> GetUsersFollows(int first = 20, string after = null, string toId = null, string fromId = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if(string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(toId) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("to_id", toId));
            }

            if (string.IsNullOrEmpty(fromId) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("from_id", fromId));
            }

            var responseStream = await httpClient.GetAsync(_getUsersFollowsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponseWithTotal<HelixFollow>>(responseStream);
        }

    }
}
