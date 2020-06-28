using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchNotFoundException : Exception
    {

        public TwitchNotFoundException() : base()
        {
        }

        public TwitchNotFoundException(string message) : base(message)
        {
        }

        public TwitchNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
