using System;

namespace Ken.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewDependencyValidationException : Exception
    {
        public StudentViewDependencyValidationException(Exception innerException)
            : base("Student view dependency validation error occurred, try again.", innerException) { }
    }
}
