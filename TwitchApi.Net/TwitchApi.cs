using System.Collections.Generic;
using System.Linq;
using TwitchApi.Net.Utility;

namespace TwitchApi.Net
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

        private string GetQueryForParameters(string parameterName, IEnumerable<string> parameters)
        {
            return string.Join("&", parameters.Select(x => $"{parameterName}={x}"));
        }

        private TwitchHttpClient GetHttpClient()
        {
            return new TwitchHttpClient(_ratelimitBypass);
        }

    }
}
