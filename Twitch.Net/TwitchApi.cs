using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;
        private readonly string _accessToken;
        private readonly RatelimitBypass _ratelimitBypass;


        public TwitchApi(string clientId, string accessToken = null, RatelimitBypass ratelimitBypass = null)
        {
            _clientId = clientId;
            _accessToken = accessToken;
            _ratelimitBypass = ratelimitBypass;
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_ratelimitBypass);
        }

    }
}
