using Bunit;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Models.StudentViews.Exceptions;
using Ken.Portal.Web.Services.StudentViews;
using Ken.Portal.Web.Views.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Tynamix.ObjectFiller;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Views.StudentRegistrationComponents
{
    public partial class StudentRegistrationComponentTests : TestContext
    {
        private readonly Mock<IStudentViewService> studentViewServiceMock;
        private IRenderedComponent<StudentRegistrationComponent> renderedStudentRegistrationComponent;

        public StudentRegistrationComponentTests()
        {
            this.studentViewServiceMock = new Mock<IStudentViewService>();
            this.Services.AddScoped(services => this.studentViewServiceMock.Object);
            this.Services.AddServerSideBlazor();
        }

        private static StudentView CreateRandomStudentView() =>
            CreateStudentFiller().Create();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        public static TheoryData StudentViewValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string validationMessage = randomMessage;
            var innerValidationException = new Exception(validationMessage);

            return new TheoryData<Exception>
            {
                new StudentViewValidationException(innerValidationException),
                new StudentViewDependencyValidationException(innerValidationException),
            };
        }

        public static TheoryData StudentViewDependencyServiceExceptions()
        {
            var innerValidationException = new Exception();

            return new TheoryData<Exception>
            {
                new StudentViewDependencyException(innerValidationException),
                new StudentViewServiceException(innerValidationException),
            };
        }

        private static Filler<StudentView> CreateStudentFiller()
        {
            var filler = new Filler<StudentView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}
