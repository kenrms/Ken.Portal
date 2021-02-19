using Ken.Portal.Web.Brokers.API;
using Ken.Portal.Web.Brokers.Logging;
using Ken.Portal.Web.Models.Students;
using System;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Student> RegisterStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
