using System;

namespace Ken.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewValidationException : Exception
    {
        public StudentViewValidationException(Exception innerException)
            : base("Student view validation error occurred, try again.", innerException) { }
    }
}
