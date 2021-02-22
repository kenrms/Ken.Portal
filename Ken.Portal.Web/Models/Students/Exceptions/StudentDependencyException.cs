using System;

namespace Ken.Portal.Web.Models.Students.Exceptions
{
    public class StudentDependencyException : Exception
    {
        public StudentDependencyException(Exception innerException)
            : base("Student dependency error occurred, contact support.", innerException) { }
    }
}
