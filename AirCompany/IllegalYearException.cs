using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class IllegalYearException : Exception
    {
        //
        // Summary:
        //     Initializes a new instance of the IllegalYearException class.
        public IllegalYearException(){
        }
        //
        // Summary:
        //     Initializes a new instance of the IllegalYearException class with a specified
        //     error message.
        //
        // Parameters:
        //   message:
        //     The message that describes the error.
        public IllegalYearException(string message): base(message){
        }
    }
}
