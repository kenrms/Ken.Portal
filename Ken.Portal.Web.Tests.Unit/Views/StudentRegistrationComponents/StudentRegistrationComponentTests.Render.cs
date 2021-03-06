﻿using Bunit;
using FluentAssertions;
using Ken.Portal.Web.Models.Colors;
using Ken.Portal.Web.Models.ContainerComponents;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Views.Components;
using Moq;
using System;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Views.StudentRegistrationComponents
{
    public partial class StudentRegistrationComponentTests : TestContext
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given
            ComponentState expectedComponentState = ComponentState.Loading;

            // when
            var initialStudentRegistrationComponent = new StudentRegistrationComponent();

            // then
            initialStudentRegistrationComponent.State.Should().Be(expectedComponentState);
            initialStudentRegistrationComponent.Exception.Should().BeNull();
            initialStudentRegistrationComponent.StudentIdentityTextBox.Should().BeNull();
            initialStudentRegistrationComponent.StudentFirstNameTextBox.Should().BeNull();
            initialStudentRegistrationComponent.StudentMiddleNameTextBox.Should().BeNull();
            initialStudentRegistrationComponent.StudentLastNameTextBox.Should().BeNull();
            initialStudentRegistrationComponent.StudentGenderDropDown.Should().BeNull();
            initialStudentRegistrationComponent.DateOfBirthPicker.Should().BeNull();
            initialStudentRegistrationComponent.StatusLabel.Should().BeNull();
            initialStudentRegistrationComponent.SubmitButton.Should().BeNull();
            initialStudentRegistrationComponent.StudentView.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedComponentState = ComponentState.Content;
            string expectedIdentityTextBoxPlaceholder = "Student Identity";
            string expectedFirstNameTextBoxPlaceholder = "First Name";
            string expectedMiddleNameTextBoxPlaceholder = "Middle Name";
            string expectedLastNameTextBoxPlaceholder = "Last Name";
            string expectedSubmitButtonLabel = "Submit Student";

            // when
            this.renderedStudentRegistrationComponent =
                RenderComponent<StudentRegistrationComponent>();

            // then
            this.renderedStudentRegistrationComponent.Instance.StudentView
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.State
                .Should().Be(expectedComponentState);

            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox.Placeholder
                .Should().Be(expectedIdentityTextBoxPlaceholder);

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox.Placeholder
                .Should().Be(expectedFirstNameTextBoxPlaceholder);

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox.Placeholder
                .Should().Be(expectedMiddleNameTextBoxPlaceholder);

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox.Placeholder
                .Should().Be(expectedLastNameTextBoxPlaceholder);

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown.Value
                .Should().BeOfType(typeof(StudentViewGender));

            this.renderedStudentRegistrationComponent.Instance.DateOfBirthPicker
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.DateOfBirthPicker.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.IsDisabled
                .Should().BeFalse();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.Label
                .Should().Be(expectedSubmitButtonLabel);

            this.renderedStudentRegistrationComponent.Instance.StatusLabel
                .Should().NotBeNull();

            this.renderedStudentRegistrationComponent.Instance.StatusLabel.Value
                .Should().BeNull();

            this.renderedStudentRegistrationComponent.Instance.Exception.Should().BeNull();
            this.studentViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldDisplaySubmittingStatusAndDisableControlsBeforeStudentIsSubmittedCompletes()
        {
            // given
            StudentView someStudentView = CreateRandomStudentView();

            this.studentViewServiceMock.Setup(service =>
                service.AddStudentViewAsync(It.IsAny<StudentView>()))
                    .ReturnsAsync(
                        value: someStudentView,
                        delay: TimeSpan.FromMilliseconds(500));

            // when
            this.renderedStudentRegistrationComponent =
                RenderComponent<StudentRegistrationComponent>();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.Click();

            // then
            this.renderedStudentRegistrationComponent.Instance.StatusLabel.Value
                .Should().BeEquivalentTo("Submitting...");

            this.renderedStudentRegistrationComponent.Instance.StatusLabel.Color
                .Should().Be(Color.Black);

            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.DateOfBirthPicker.IsDisabled
                .Should().BeTrue();

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.IsDisabled
                .Should().BeTrue();


            this.studentViewServiceMock.Verify(service =>
                service.AddStudentViewAsync(It.IsAny<StudentView>()),
                    Times.Once);
        }

        [Fact]
        public void ShouldSubmitStudent()
        {
            // given
            StudentView randomStudentView = CreateRandomStudentView();
            StudentView inputStudentView = randomStudentView;
            StudentView expectedStudentView = inputStudentView;

            // when
            this.renderedStudentRegistrationComponent =
                RenderComponent<StudentRegistrationComponent>();

            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox
                .SetValue(inputStudentView.IdentityNumber);

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox
                .SetValue(inputStudentView.FirstName);

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox
                .SetValue(inputStudentView.MiddleName);

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox
                .SetValue(inputStudentView.LastName);

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown
                .SetValue(inputStudentView.Gender);

            this.renderedStudentRegistrationComponent.Instance.DateOfBirthPicker
                .SetValue(inputStudentView.BirthDate);

            this.renderedStudentRegistrationComponent.Instance.SubmitButton.Click();

            // then
            this.renderedStudentRegistrationComponent.Instance.StudentIdentityTextBox.Value
                .Should().BeEquivalentTo(expectedStudentView.IdentityNumber);

            this.renderedStudentRegistrationComponent.Instance.StudentFirstNameTextBox.Value
                .Should().BeEquivalentTo(expectedStudentView.FirstName);

            this.renderedStudentRegistrationComponent.Instance.StudentMiddleNameTextBox.Value
                .Should().BeEquivalentTo(expectedStudentView.MiddleName);

            this.renderedStudentRegistrationComponent.Instance.StudentLastNameTextBox.Value
                .Should().BeEquivalentTo(expectedStudentView.LastName);

            this.renderedStudentRegistrationComponent.Instance.StudentGenderDropDown.Value
                .Should().Be(expectedStudentView.Gender);

            this.renderedStudentRegistrationComponent.Instance.DateOfBirthPicker.Value
                .Should().Be(expectedStudentView.BirthDate);

            this.renderedStudentRegistrationComponent.Instance.StatusLabel.Value
                .Should().Be("Submitted Successfully");

            this.renderedStudentRegistrationComponent.Instance.StatusLabel.Color
                .Should().Be(Color.Green);

            this.studentViewServiceMock.Verify(service =>
                service.AddStudentViewAsync(this.renderedStudentRegistrationComponent.Instance.StudentView),
                    Times.Once);

            this.studentViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
