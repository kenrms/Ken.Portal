using Ken.Portal.Web.Models.Students;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Brokers.API
{
    public partial class ApiBroker
    {
        private const string RelativeUrl = "apt/students";

        public async ValueTask<Student> PostStudentAsync(Student student) =>
            await this.PostAsync(RelativeUrl, student);
    }
}
