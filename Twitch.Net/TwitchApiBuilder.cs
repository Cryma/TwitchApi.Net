using System;
using Twitch.Net.Exceptions;
using Twitch.Net.Interfaces;
using Twitch.Net.Strategies;

namespace Twitch.Net
{
    public class TwitchApiBuilder
    {

        private readonly string _clientId;

        private IAccessTokenStrategy _accessTokenStrategy;
        private IRateLimitStrategy _rateLimitStrategy;

        public TwitchApiBuilder(string clientId)
        {
            _clientId = clientId;

            _rateLimitStrategy = new RateLimitIgnoreStrategy();
        }

        public TwitchApiBuilder WithClientSecret(string clientSecret)
        {
            if (clientSecret == null)
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            _accessTokenStrategy = new AccessTokenGeneratedStrategy(_clientId, clientSecret);

            return this;
        }

        public TwitchApiBuilder WithAccessToken(string accessToken)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            _accessTokenStrategy = new AccessTokenSuppliedStrategy(accessToken);

            return this;
        }

        public TwitchApiBuilder WithRateLimitBypass()
        {
            _rateLimitStrategy = new RateLimitWaitBetweenRequestsStrategy();

            return this;
        }

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
