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
            // TODO: Validate parameter

            _accessTokenStrategy = new AccessTokenGeneratedStrategy(_clientId, clientSecret);

            return this;
        }

        public TwitchApiBuilder WithAccessToken(string accessToken)
        {
            // TODO: Validate parameter

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
            // TODO: Check if AccessTokenStrategy was set

            return new TwitchApi(_clientId, _accessTokenStrategy, _rateLimitStrategy);
        }

    }
}
