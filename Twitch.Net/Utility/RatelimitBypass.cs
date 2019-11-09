using System;
using System.Threading;
using System.Threading.Tasks;

namespace Twitch.Net.Utility
{
    public class RatelimitBypass
    {

        private const int ActionsPerMinute = 800;
        private const int MillisecondDelayBetweenActions = 1000 / (ActionsPerMinute / 60) + 1;

        private DateTime _lastAction = DateTime.UtcNow;

        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task Wait()
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                var msSinceLastAction = (int)Math.Floor((DateTime.UtcNow - _lastAction).TotalMilliseconds);

                if (msSinceLastAction < MillisecondDelayBetweenActions)
                {
                    await Task.Delay(MillisecondDelayBetweenActions - msSinceLastAction);
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
