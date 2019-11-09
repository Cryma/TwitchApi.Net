using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchTooManyRequestsException : Exception
    {
        public TwitchTooManyRequestsException(string message) : base(message)
        {
        }

    }
}
