using System;

namespace Ken.Portal.Web.Models.Students.Exceptions
{
    public class StudentValidationException : Exception
    {
        public StudentValidationException(Exception innerException)
            : base("Student validation error occurred, try again.", innerException) { }
    }
}
