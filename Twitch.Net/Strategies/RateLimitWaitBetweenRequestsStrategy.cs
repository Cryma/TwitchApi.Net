using System;
using System.Threading;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;

namespace Twitch.Net.Strategies
{
    internal class RateLimitWaitBetweenRequestsStrategy : IRateLimitStrategy
    {

        private const int _actionsPerMinute = 800;
        private const int _millisecondDelayBetweenActions = 1000 / (_actionsPerMinute / 60) + 1;

        private DateTime _lastAction = DateTime.UtcNow;

        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task Wait()
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                var msSinceLastAction = (int)Math.Floor((DateTime.UtcNow - _lastAction).TotalMilliseconds);

                if (msSinceLastAction < _millisecondDelayBetweenActions)
                {
                    await Task.Delay(_millisecondDelayBetweenActions - msSinceLastAction);
                }

                _lastAction = DateTime.UtcNow;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

    }
}
