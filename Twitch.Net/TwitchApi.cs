using Twitch.Net.Elements;
using Twitch.Net.Interfaces;
using Twitch.Net.Utility;

namespace Twitch.Net
{
    public class TwitchApi
    {

        public IAdActions Ads { get; }
        public IClipActions Clips { get; }
        public IGameActions Games { get; }
        public IStreamActions Streams { get; }
        public IUserActions Users { get; }
        public IVideoActions Videos { get; }

        private readonly string _clientId;

        private readonly IAccessTokenStrategy _accessTokenStrategy;
        private readonly IRateLimitStrategy _rateLimitStrategy;

        internal TwitchApi(string clientId, IAccessTokenStrategy accessTokenStrategy, IRateLimitStrategy rateLimitStrategy)
        {
            _clientId = clientId;

            _accessTokenStrategy = accessTokenStrategy;
            _rateLimitStrategy = rateLimitStrategy;

            Ads = new AdActions(GetHttpClient);
            Clips = new ClipActions(GetHttpClient);
            Games = new GameActions(GetHttpClient);
            Streams = new StreamActions(GetHttpClient);
            Users = new UserActions(GetHttpClient);
            Videos = new VideoActions(GetHttpClient);
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_clientId, _accessTokenStrategy, _rateLimitStrategy);
        }

    }
}
