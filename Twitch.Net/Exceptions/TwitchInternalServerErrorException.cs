using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchInternalServerErrorException : Exception
    {
        public TwitchInternalServerErrorException() : base()
        {
        }

        public TwitchInternalServerErrorException(string message) : base(message)
        {
        }

        public TwitchInternalServerErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
