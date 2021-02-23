using System;

namespace Ken.Portal.Web.Models.StudentViews.Exceptions
{
    public class InvalidStudentViewException : Exception
    {
        public InvalidStudentViewException(string parameterName, object parameterValue)
            : base($"Invalid Student View error occured. " +
                 $"parameter name: {parameterName}, " +
                 $"parameter value: {parameterValue}")
        { }
    }
}
