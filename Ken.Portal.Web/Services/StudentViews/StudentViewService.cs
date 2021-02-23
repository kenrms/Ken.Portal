using Ken.Portal.Web.Brokers.DateTimes;
using Ken.Portal.Web.Brokers.Logging;
using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Services.Students;
using Ken.Portal.Web.Services.Users;
using System;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Services.StudentViews
{
    public partial class StudentViewService : IStudentViewService
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

        public ValueTask<StudentView> AddStudentViewAsync(StudentView studentView) =>
            TryCatch(async () =>
            {
                ValidateStudentView(studentView);
                Student student = MapToStudent(studentView);
                await this.studentService.RegisterStudentAsync(student);

                return studentView;
            });

        private Student MapToStudent(StudentView studentView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTime();

            return new Student
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                IdentityNumber = studentView.IdentityNumber,
                FirstName = studentView.FirstName,
                MiddleName = studentView.MiddleName,
                LastName = studentView.LastName,
                Gender = (StudentGender)studentView.Gender,
                BirthDate = studentView.BirthDate,
                CreatedBy = currentLoggedInUserId,
                UpdatedBy = currentLoggedInUserId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime,
            };
        }
    }
}
