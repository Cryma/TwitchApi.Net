using System;
using System.Threading;
using System.Threading.Tasks;

namespace Twitch.Net.Utility
{
    internal class RatelimitBypass
    {

        private readonly int _actionsPerMinute;

        private int _millisecondDelayBetweenActions => 1000 / (_actionsPerMinute / 60) + 1;

        private DateTime _lastAction = DateTime.UtcNow;

        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public RatelimitBypass(int actionsPerMinute)
        {
            _actionsPerMinute = actionsPerMinute;
        }
        
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
