﻿using Ken.Portal.Web.Models.Students;
using Ken.Portal.Web.Models.Students.Exceptions;
using System;

namespace Ken.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        private void ValidateStudent(Student student)
        {
            switch (student)
            {
                case null:
                    throw new NullStudentException();

                case { } when IsInvalid(student.Id):
                    throw new InvalidStudentException(
                        parameterName: nameof(Student.Id),
                        parameterValue: student.Id);

                case { } when IsInvalid(student.UserId):
                    throw new InvalidStudentException(
                        parameterName: nameof(Student.UserId),
                        parameterValue: student.UserId);

                case { } when IsInvalid(student.IdentityNumber):
                    throw new InvalidStudentException(
                        parameterName: nameof(Student.IdentityNumber),
                        parameterValue: student.IdentityNumber);
            }
        }

        private static bool IsInvalid(Guid id) => id == Guid.Empty;
        private static bool IsInvalid(string text) => string.IsNullOrWhiteSpace(text);
    }
}
