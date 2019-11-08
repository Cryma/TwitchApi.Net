using System;

namespace Twitch.Net.Exceptions
{
    public class TwitchInternalServerErrorException : Exception
    {
        public TwitchInternalServerErrorException(string message) : base(message)
        {
        }

    }
}
