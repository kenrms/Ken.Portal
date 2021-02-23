using Bunit;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Services.StudentViews;
using Ken.Portal.Web.Views.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Tynamix.ObjectFiller;

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

        private static Filler<StudentView> CreateStudentFiller()
        {
            var filler = new Filler<StudentView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }

    }
}
