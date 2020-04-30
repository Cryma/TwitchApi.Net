using Twitch.Net.Interfaces;
using Twitch.Net.Strategies;
using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;

        private IAccessTokenStrategy _accessTokenStrategy;
        private IRateLimitStrategy _rateLimitStrategy;

        internal TwitchApi(string clientId, IAccessTokenStrategy accessTokenStrategy, IRateLimitStrategy rateLimitStrategy)
        {
            _clientId = clientId;

            _accessTokenStrategy = accessTokenStrategy;
            _rateLimitStrategy = rateLimitStrategy;
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_clientId, _accessTokenStrategy, _rateLimitStrategy);
        }

    }
}
