using System;

namespace Ken.Portal.Web.Models.Students.Exceptions
{
    public class StudentServiceException : Exception
    {
        public StudentServiceException(Exception innerException)
            : base("Student service error occurred, contact support.", innerException) { }
    }
}
