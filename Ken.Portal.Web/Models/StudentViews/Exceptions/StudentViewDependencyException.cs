using System;

namespace Ken.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewDependencyException : Exception
    {
        public StudentViewDependencyException(Exception innerException)
            : base("Student view dependency error occurred, contact support.", innerException) { }
    }
}
