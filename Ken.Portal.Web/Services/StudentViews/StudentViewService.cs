using Ken.Portal.Web.Brokers.DateTimes;
using Ken.Portal.Web.Brokers.Logging;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Services.Students;
using Ken.Portal.Web.Services.Users;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.StudentViews
{
    public class StudentViewService : IStudentViewService
    {
        private readonly IStudentService studentService;
        private readonly IUserService userService;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentViewService(
            IStudentService studentService,
            IUserService userService,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.studentService = studentService;
            this.userService = userService;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<StudentView> AddStudentViewAsync(StudentView studentView)
        {
            throw new System.NotImplementedException();
        }
    }
}
