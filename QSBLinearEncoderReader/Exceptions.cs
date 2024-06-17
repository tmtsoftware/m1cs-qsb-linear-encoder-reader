using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    public class InvalidConnectionSettingException : Exception
    {
        public InvalidConnectionSettingException(string message)
            : base(message)
        {
        }
    }
    public class InvalidConnectionStateException : Exception
    {
        public InvalidConnectionStateException(ConnectionState currentState, string message)
            : base("Current state is \"" + currentState.ToString() + "\". " + message)
        {
        }
    }
    public class UnexpectedResponseException : Exception
    {
        public UnexpectedResponseException(string message)
            : base(message)
        {
        }

        public UnexpectedResponseException(string message, string response)
            : base(message + " (Response: \"" + response + "\")")
        {
        }

        public UnexpectedResponseException(string message, string response, Exception innerException)
            : base(message + " (Response: \"" + response + "\")", innerException)
        {
        }

        public UnexpectedResponseException(string message, string command, string response)
            : base(message + " (Command: \"" + command + "\", response: \"" + response + "\")")
        {
        }

        public UnexpectedResponseException(string message, string command, string response, Exception innerException)
            : base(message + " (Command: \"" + command + "\", response: \"" + response + "\")", innerException)
        {
        }
    }
}
