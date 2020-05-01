using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchUnauthorizedException : Exception
    {
        public TwitchUnauthorizedException() : base()
        {
        }

        public TwitchUnauthorizedException(string message) : base(message)
        {
        }

        public TwitchUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
