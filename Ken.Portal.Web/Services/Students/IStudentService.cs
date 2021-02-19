using Ken.Portal.Web.Models.Students;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.Students
{
    interface IStudentService
    {
        ValueTask<Student> RegisterStudentAsync(Student student);
    }
}
