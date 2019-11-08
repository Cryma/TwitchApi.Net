using System;

namespace TwitchApi.Net.Exceptions
{
    public class TwitchTooManyRequestsException : Exception
    {
        public TwitchTooManyRequestsException(string message) : base(message)
        {
        }

    }
}
