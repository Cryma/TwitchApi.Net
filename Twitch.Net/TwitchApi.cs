using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;


        public TwitchApi(string clientId)
        {
            _clientId = clientId;
        }

        private HttpClient GetPreparedHttpClient()
        {
            return new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "Client-ID", _clientId }
                }
            };
        }

        private string GetQueryForParameters(string parameterName, IEnumerable<string> parameters)
        {
            return string.Join("&", parameters.Select(x => $"{parameterName}={x}"));
        }

    }
}
