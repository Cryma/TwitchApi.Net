﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class StreamActions : IStreamActions
    {

        private const string _getStreamsEndpoint = "https://api.twitch.tv/helix/streams";

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        internal StreamActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixPaginatedResponse<HelixStream>> GetStreams(int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

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

        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithGameIds(string[] gameIds, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

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

        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserIds(string[] userIds, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

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

        public async Task<HelixPaginatedResponse<HelixStream>> GetStreamsWithUserLogins(string[] userLogins, int first = 20, string[] languages = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

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
