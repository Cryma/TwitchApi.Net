using System.Threading.Tasks;
using Twitch.Net.Interfaces;

namespace Twitch.Net.Strategies
{
    internal class AccessTokenSuppliedStrategy : IAccessTokenStrategy
    {

        private readonly string _accessToken;

        internal AccessTokenSuppliedStrategy(string accessToken)
        {
            _accessToken = accessToken;
        }

        public Task<string> GetAccessToken()
        {
            return Task.FromResult(_accessToken);
        }

    }
}
