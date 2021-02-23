using System;

namespace Ken.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewServiceException : Exception
    {
        public StudentViewServiceException(Exception innerException)
            : base("Student View service error occured, contact support.", innerException) { }
    }
}
