using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchUnauthorizedException : Exception
    {
        public TwitchUnauthorizedException(string message) : base(message)
        {
        }

    }
}
