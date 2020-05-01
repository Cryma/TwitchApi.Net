using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchTooManyRequestsException : Exception
    {
        public TwitchTooManyRequestsException() : base()
        {
        }

        public TwitchTooManyRequestsException(string message) : base(message)
        {
        }

        public TwitchTooManyRequestsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
