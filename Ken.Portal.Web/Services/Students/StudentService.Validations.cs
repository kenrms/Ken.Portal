using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.Students.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        private void ValidateStudent(Student student)
        {
            if (student is null)
            {
                throw new NullStudentException();
            }
        }
    }
}
