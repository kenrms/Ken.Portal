using Bunit;
using FluentAssertions;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Views.Components;
using Moq;
using System;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Views.StudentRegistrationComponents
{
    public partial class StudentRegistrationComponentTests : TestContext
    {
        [Theory]
        [MemberData(nameof(StudentViewValidationExceptions))]
        public void ShouldRenderInnerExceptionMessageIfValidationErrorOccured(
            Exception studentViewValidationException)
        {
            // given
            string expectedErrorMessage =
                studentViewValidationException.InnerException.Message;

            this.studentViewServiceMock.Setup(service =>
                service.AddStudentViewAsync(It.IsAny<StudentView>()))
                .ThrowsAsync(studentViewValidationException);

            // when
            this.renderedStudentRegistrationComponent =
                RenderComponent<StudentRegistrationComponent>();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.Click();

            // then
            this.renderedStudentRegistrationComponent.Instance.ErrorLabel.Value
                .Should().BeEquivalentTo(expectedErrorMessage);

            this.studentViewServiceMock.Verify(service =>
                service.AddStudentViewAsync(It.IsAny<StudentView>()),
                    Times.Once);
        }
    }
}
