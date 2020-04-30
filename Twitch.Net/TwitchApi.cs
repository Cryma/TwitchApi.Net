using Twitch.Net.Interfaces;
using Twitch.Net.Strategies;
using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;
        private readonly string _accessToken;
        private IRateLimitStrategy _rateLimitStrategy;

        /// <summary>
        /// Initialize the Twitch API
        ///
        /// <para>Note: Without accessToken, the rate-limit is drastically reduced.</para>
        /// </summary>
        /// <param name="clientId">Developer application client id</param>
        /// <param name="accessToken">Developer application access token</param>
        public TwitchApi(string clientId, string accessToken = null)
        {
            _clientId = clientId;
            _accessToken = accessToken;

            _rateLimitStrategy = new RateLimitIgnoreStrategy();
        }

        /// <summary>
        /// Add a rate limit bypass by waiting between requests
        /// </summary>
        /// <returns></returns>
        public TwitchApi WithRateLimitBypass()
        {
            _rateLimitStrategy = new RateLimitWaitBetweenRequestsStrategy();

            return this;
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_rateLimitStrategy, _clientId, _accessToken);
        }

    }
}
