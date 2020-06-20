using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class EntitlementActions : IEntitlementActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _createEntitlementGrantUploadUrlEndpoint = "https://api.twitch.tv/helix/entitlements/upload";
        private const string _entitlementCodeEndpoint = "https://api.twitch.tv/helix/entitlements/codes";

        internal EntitlementActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixEntitlementGrant>> CreateEntitlementGrantsUploadUrl(string manifestId, HelixEntitlementGrantType type)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("manifest_id", manifestId),
                new KeyValuePair<string, string>("type", GetEntitlementGrantType(type))
            };

            var responseStream = await httpClient.PostAsync(_createEntitlementGrantUploadUrlEndpoint, parameters);

            var responseModel = await JsonSerializer.DeserializeAsync<HelixResponse<HelixEntitlementGrant>>(responseStream);
            if (responseModel.Data.Length == 1)
            {
                responseModel.Data[0].Url = responseModel.Data[0].Url.Replace('\u0026', '&');
            }

            return responseModel;
        }

        public async Task<HelixResponse<HelixEntitlementCode>> GetCodeStatus(string[] codes, string userId)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId)
            };

            parameters.AddRange(codes.Select(code => new KeyValuePair<string, string>("code", code)));

            var responseStream = await httpClient.GetAsync(_entitlementCodeEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixEntitlementCode>>(responseStream);
        }

        public async Task<HelixResponse<HelixEntitlementCode>> RedeemCode(string[] codes, string userId)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId)
            };

            parameters.AddRange(codes.Select(code => new KeyValuePair<string, string>("code", code)));

            var responseStream = await httpClient.PostAsync(_entitlementCodeEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixEntitlementCode>>(responseStream);
        }

        private string GetEntitlementGrantType(HelixEntitlementGrantType type)
        {
            switch (type)
            {
                case HelixEntitlementGrantType.BulkDropsGrant:
                    return "bulk_drops_grant";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    }
}
