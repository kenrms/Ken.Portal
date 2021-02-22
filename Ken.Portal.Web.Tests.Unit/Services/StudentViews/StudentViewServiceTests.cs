using KellermanSoftware.CompareNetObjects;
using Ken.Portal.Web.Brokers.DateTimes;
using Ken.Portal.Web.Brokers.Logging;
using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Services.Students;
using Ken.Portal.Web.Services.StudentViews;
using Ken.Portal.Web.Services.Users;
using Moq;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace Ken.Portal.Web.Tests.Unit.Services.StudentViews
{
    public partial class StudentViewServiceTests
    {
        private readonly Mock<IStudentService> studentServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IStudentViewService studentViewService;

        public StudentViewServiceTests()
        {
            this.studentServiceMock = new Mock<IStudentService>();
            this.userServiceMock = new Mock<IUserService>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            var compareConfig = new ComparisonConfig();
            compareConfig.IgnoreProperty<Student>(student => student.Id);
            compareConfig.IgnoreProperty<Student>(student => student.UserId);
            this.compareLogic = new CompareLogic(compareConfig);

            this.studentViewService = new StudentViewService(
                studentService: this.studentServiceMock.Object,
                userService: this.userServiceMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private Expression<Func<Student, bool>> SameStudentAs(Student expectedStudent)
        {
            return actualStudent => this.compareLogic.Compare(expectedStudent, actualStudent)
                .AreEqual;
        }

        private static dynamic CreateRandomStudentViewProperties(
            DateTimeOffset auditDates,
            Guid auditIds)
        {
            StudentGender randomstudentGender = GetRandomGender();

            return new
            {
                Id = Guid.NewGuid(),
                UserId = GetRandomString(),
                IdentityNumber = Guid.NewGuid().ToString(),
                FirstName = GetRandomName(),
                MiddleName = GetRandomName(),
                LastName = GetRandomName(),
                BirthDate = GetRandomDate(),
                Gender = randomstudentGender,
                GenderView = (StudentViewGender)randomstudentGender,
                CreatedDate = auditDates,
                UpdatedDate = auditDates,
                CreatedBy = auditIds,
                UpdatedBy = auditIds,
            };
        }

        private static string GetRandomName() =>
            new RealNames().GetValue();

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static StudentGender GetRandomGender()
        {
            int studentViewGenderCount = Enum.GetValues(typeof(StudentGender)).Length;
            int randomStudentViewGenderValue = new IntRange(min: 0, max: studentViewGenderCount).GetValue();

            return (StudentGender)randomStudentViewGenderValue;
        }
    }
}
