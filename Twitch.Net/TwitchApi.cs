using Twitch.Net.Elements;
using Twitch.Net.Interfaces;
using Twitch.Net.Utility;

namespace Twitch.Net
{
    public class TwitchApi
    {

        public IAdActions Ads { get; }
        public IAnalyticActions Analytics { get; }
        public IBitActions Bits { get; }
        public IClipActions Clips { get; }
        public IEntitlementActions Entitlements { get; }
        public IGameActions Games { get; }
        public IModerationActions Moderation { get; }
        public ISearchActions Search { get; }
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
            Analytics = new AnalyticActions(GetHttpClient);
            Bits = new BitActions(GetHttpClient);
            Clips = new ClipActions(GetHttpClient);
            Entitlements = new EntitlementActions(GetHttpClient);
            Games = new GameActions(GetHttpClient);
            Moderation = new ModerationActions(GetHttpClient);
            Search = new SearchActions(GetHttpClient);
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
