using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;
        private readonly string _accessToken;
        private readonly RatelimitBypass _ratelimitBypass;


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
            return new TwitchHttpClient(_ratelimitBypass);
        }

    }
}
