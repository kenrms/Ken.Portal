using Ken.Portal.Web.Models.Students;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Brokers.API
{
    public partial interface IApiBroker
    {
        ValueTask<Student> PostStudentAsync(Student student);
    }
}
