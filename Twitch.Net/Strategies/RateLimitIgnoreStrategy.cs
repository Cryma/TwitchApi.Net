using System.Threading.Tasks;
using Twitch.Net.Interfaces;

namespace Twitch.Net.Strategies
{
    internal class RateLimitIgnoreStrategy : IRateLimitStrategy
    {
        public Task Wait()
        {
            return Task.CompletedTask;
        }

    }
}
