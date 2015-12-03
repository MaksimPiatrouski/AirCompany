using System;

namespace Exceptions
{
    class IllegalMinMaxValuesException : Exception
    {
        //
        // Summary:
        //     Initializes a new instance of the IllegalMinMaxValuesException class.
        public IllegalMinMaxValuesException()
        {
        }
        //
        // Summary:
        //     Initializes a new instance of the IllegalMinMaxValuesException class with a specified
        //     error message.
        //
        // Parameters:
        //   message:
        //     The message that describes the error.
        public IllegalMinMaxValuesException(string message) : base(message)
        {
        }
    }
}
