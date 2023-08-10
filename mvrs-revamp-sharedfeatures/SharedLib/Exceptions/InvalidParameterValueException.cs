using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Exceptions
{
    public class InvalidParameterValueException:System.Exception
    {

        public static string DefaultMessage = "One or More parameters are not valid.";
        public InvalidParameterValueException (string message) : base(message)
        {

        }
    }
}
