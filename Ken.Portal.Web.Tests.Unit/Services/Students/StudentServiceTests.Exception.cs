using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.Students.Exceptions;
using Moq;
using RESTFulSense.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        public static TheoryData ValidationApiExceptions()
        {
            var exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException = new HttpResponseBadRequestException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseConflictException =
                new HttpResponseConflictException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseBadRequestException,
                httpResponseConflictException
            };
        }

        [Theory]
        [MemberData(nameof(ValidationApiExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnRegisterIfBadRequestErrorOccursAndLogItAsync(
            Exception httpResponseValidationException)
        {
            // given
            Student someStudent = CreateRandomStudent();

            var expectedDependencyValidationException =
                new StudentDependencyValidationException(
                    httpResponseValidationException);

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(httpResponseValidationException);

            // when
            ValueTask<Student> registerStudentTask =
                this.studentService.RegisterStudentAsync(someStudent);

            // then
            await Assert.ThrowsAsync<StudentDependencyValidationException>(() =>
                registerStudentTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(
                    SameExceptionAs(expectedDependencyValidationException))),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        public static TheoryData CriticalApiExceptions()
        {
            var exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            var httpResponseUnauthorizedException =
                new HttpResponseUnauthorizedException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseUrlNotFoundException,
                httpResponseUnauthorizedException
            };
        }

        [Theory]
        [MemberData(nameof(CriticalApiExceptions))]
        public async Task ShouldThrowCriticalDependencyExceptionOnRegisterIfUrlNotFoundErrorOccursAndLogItAsync(
            Exception httpResponseCriticalException)
        {
            // given
            Student someStudent = CreateRandomStudent();

            var expectedDependencyException =
                new StudentDependencyException(
                    httpResponseCriticalException);

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(httpResponseCriticalException);

            // when
            ValueTask<Student> registerStudentTask =
                this.studentService.RegisterStudentAsync(someStudent);

            // then
            await Assert.ThrowsAsync<StudentDependencyException>(() =>
                registerStudentTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(
                    SameExceptionAs(expectedDependencyException))),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRegisterIfServerInternalErrorOccursAndLogItAsync()
        {
            // given
            Student someStudent = CreateRandomStudent();
            var exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseInternalServerErrorException =
                new HttpResponseInternalServerErrorException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            var expectedStudentDependencyExpception =
                new StudentDependencyException(
                    httpResponseInternalServerErrorException);

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(httpResponseInternalServerErrorException);

            // when
            ValueTask<Student> registerStudentTask =
                this.studentService.RegisterStudentAsync(someStudent);

            // then
            await Assert.ThrowsAsync<StudentDependencyException>(() =>
                registerStudentTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(
                    SameExceptionAs(expectedStudentDependencyExpception))),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
