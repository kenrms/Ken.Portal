using Ken.Portal.Web.Brokers.API;
using Ken.Portal.Web.Brokers.Logging;
using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Services.Students;
using Moq;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace Ken.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly StudentService studentService;

        public StudentServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.studentService = new StudentService(
                apiBroker: this.apiBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static Student CreateRandomStudent() =>
            CreateStudentFiller().Create();

        private static string GetRandomString() => new MnemonicString().GetValue();

        private static Filler<Student> CreateStudentFiller()
        {
            var filler = new Filler<Student>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}
