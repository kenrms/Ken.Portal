using System;

namespace Ken.Portal.Web.Models.Students.Exceptions
{
    public class NullStudentException : Exception
    {
        public NullStudentException()
            : base("Null student error occurred.") { }
    }
}
