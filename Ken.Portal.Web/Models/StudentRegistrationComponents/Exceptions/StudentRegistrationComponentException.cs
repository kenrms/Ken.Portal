using System;

namespace Ken.Portal.Web.Models.StudentRegistrationComponents.Exceptions
{
    public class StudentRegistrationComponentException : Exception
    {
        public StudentRegistrationComponentException(Exception innerException)
            : base("Error occurred, contact support", innerException)
        {

        }
    }
}
