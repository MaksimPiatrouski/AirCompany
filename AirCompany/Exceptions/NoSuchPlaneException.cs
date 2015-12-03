using System;

namespace Exceptions
{
    class NoSuchPlaneException : Exception
    {
        //
        // Summary:
        //     Initializes a new instance of the NoSuchPlaneException class.
        public NoSuchPlaneException()
        {
        }
        //
        // Summary:
        //     Initializes a new instance of the NoSuchPlaneException class with a specified
        //     error message.
        //
        // Parameters:
        //   message:
        //     The message that describes the error.
        public NoSuchPlaneException(string message) : base(message)
        {
        }
    }
}
