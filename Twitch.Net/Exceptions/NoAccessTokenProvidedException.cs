using System;
using System.Collections.Generic;
using System.Text;

namespace Twitch.Net.Exceptions
{
    public class NoAccessTokenProvidedException : Exception
    {
        public NoAccessTokenProvidedException() : base()
        {
        }

        public NoAccessTokenProvidedException(string message) : base(message)
        {
        }

        public NoAccessTokenProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
