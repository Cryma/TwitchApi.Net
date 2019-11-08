﻿using System.Text.Json;
using System.Threading.Tasks;
using TwitchApi.Net.Models;
using TwitchApi.Net.Response;
using TwitchApi.Net.Utility;

namespace TwitchApi.Net
{
    public partial class TwitchApi
    {

        private const string _getUsersEndpoint = "https://api.twitch.tv/helix/users";

        public async Task<TwitchResponse<TwitchUser>> GetUsers(string[] ids)
        {
            using var httpClient = GetHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", ids)}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(responseStream);
        }

    }
}