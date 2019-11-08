using System.Collections.Generic;
using System.Linq;

namespace TwitchApi.Net
{
    public partial class TwitchApi
    {

        private readonly string _clientId;


        public TwitchApi(string clientId)
        {
            _clientId = clientId;
        }

        private string GetQueryForParameters(string parameterName, IEnumerable<string> parameters)
        {
            return string.Join("&", parameters.Select(x => $"{parameterName}={x}"));
        }

    }
}
