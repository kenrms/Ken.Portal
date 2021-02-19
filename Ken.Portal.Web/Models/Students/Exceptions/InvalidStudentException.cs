using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Models.Students.Exceptions
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string parameterName, object parameterValue)
            : base("Invalid student error occurred, " +
                 $"parameter name: {parameterName}, " +
                 $"parameter value: {parameterValue}")
        { }
    }
}
