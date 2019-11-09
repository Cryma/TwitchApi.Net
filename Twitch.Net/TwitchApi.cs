using Twitch.Net.Utility;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;
        private readonly RatelimitBypass _ratelimitBypass;


        public TwitchApi(string clientId, RatelimitBypass ratelimitBypass = null)
        {
            _clientId = clientId;
            _ratelimitBypass = ratelimitBypass;
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_ratelimitBypass);
        }

    }
}
