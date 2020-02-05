using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;
        private readonly string _accessToken;
        private readonly RatelimitBypass _ratelimitBypass;

        /// <summary>
        /// Initialize the Twitch API
        ///
        /// <para>Note: Without accessToken, the rate-limit is drastically reduced.</para>
        /// </summary>
        /// <param name="clientId">Developer application client id</param>
        /// <param name="accessToken">Developer application access token</param>
        /// <param name="bypassRatelimit">Whether or not the rate-limit should be bypassed (by waiting between requests)</param>
        public TwitchApi(string clientId, string accessToken = null, bool bypassRatelimit = false)
        {
            _clientId = clientId;
            _accessToken = accessToken;

            if (bypassRatelimit)
            {
                _ratelimitBypass = new RatelimitBypass(string.IsNullOrEmpty(accessToken) ? 30 : 800);
            }
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_ratelimitBypass, _clientId, _accessToken);
        }

    }
}
