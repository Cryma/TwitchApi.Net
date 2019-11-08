using System;

namespace TwitchApi.Net.Exceptions
{
    public class TwitchInternalServerErrorException : Exception
    {
        public TwitchInternalServerErrorException(string message) : base(message)
        {
        }

    }
}
