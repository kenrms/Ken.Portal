using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.Students.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentIsNullAndLogItAsync()
        {
            // given
            Student invalidStudent = null;
            var nullStudentException = new NullStudentException();

            var expectedStudentValidationException =
                new StudentValidationException(nullStudentException);

            // when
            ValueTask<Student> submitStudentTask =
                this.studentService.RegisterStudentAsync(invalidStudent);

            // then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                submitStudentTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(
                    It.Is(SameExceptionAs(expectedStudentValidationException))),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRegisterIfStudentIdIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidId = Guid.Empty;
            Student randomStudent = CreateRandomStudent();
            Student invalidStudent = randomStudent;
            invalidStudent.Id = invalidId;

            var invalidStudentException = new InvalidStudentException(
                parameterName: nameof(Student.Id),
                parameterValue: invalidStudent.Id);

            var expectedStudentValidationException =
                new StudentValidationException(invalidStudentException);

            // when
            ValueTask<Student> registerStudentTask =
                this.studentService.RegisterStudentAsync(invalidStudent);

            // then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                registerStudentTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(
                    It.Is(SameExceptionAs(expectedStudentValidationException))),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(It.IsAny<Student>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
