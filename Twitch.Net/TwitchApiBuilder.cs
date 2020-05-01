using System;
using Twitch.Net.Exceptions;
using Twitch.Net.Interfaces;
using Twitch.Net.Strategies;

namespace Twitch.Net
{
    /// <summary>
    /// Handles creation of a <see cref="TwitchApi"/> instance.
    /// </summary>
    public class TwitchApiBuilder
    {

        private readonly string _clientId;

        private IAccessTokenStrategy _accessTokenStrategy;
        private IRateLimitStrategy _rateLimitStrategy;

        /// <summary>
        /// Create a new instance of <see cref="TwitchApiBuilder" />.
        /// </summary>
        /// <param name="clientId">Developer application client id</param>
        public TwitchApiBuilder(string clientId)
        {
            _clientId = clientId;

            _rateLimitStrategy = new RateLimitIgnoreStrategy();
        }

        /// <summary>
        /// Provide a developer application <paramref name="clientSecret"/> from which an
        /// access token will be generated.
        /// </summary>
        /// <param name="clientSecret">Developer application client secret</param>
        /// <returns></returns>
        public TwitchApiBuilder WithClientSecret(string clientSecret)
        {
            if (clientSecret == null)
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            _accessTokenStrategy = new AccessTokenGeneratedStrategy(_clientId, clientSecret);

            return this;
        }

        /// <summary>
        /// Provide a developer application <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">Developer application access token</param>
        /// <returns></returns>
        public TwitchApiBuilder WithAccessToken(string accessToken)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            _accessTokenStrategy = new AccessTokenSuppliedStrategy(accessToken);

            return this;
        }

        /// <summary>
        /// Bypass the rate limit by waiting between requests for a given amount of time.
        /// </summary>
        /// <returns></returns>
        public TwitchApiBuilder WithRateLimitBypass()
        {
            _rateLimitStrategy = new RateLimitWaitBetweenRequestsStrategy();

            return this;
        }

        /// <summary>
        /// Builds the <see cref="TwitchApi"/> instance.
        /// </summary>
        /// <returns><see cref="TwitchApi"/> instance</returns>
        public TwitchApi Build()
        {
            if (_accessTokenStrategy == null)
            {
                throw new NoAccessTokenProvidedException("Neither an access token nor a client secret has been provided!");
            }

            return new TwitchApi(_clientId, _accessTokenStrategy, _rateLimitStrategy);
        }

    }
}
