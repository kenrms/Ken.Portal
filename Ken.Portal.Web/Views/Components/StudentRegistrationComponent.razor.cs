using Ken.Portal.Web.Models.ContainerComponents;
using Ken.Portal.Web.Models.StudentViews;
using Ken.Portal.Web.Models.StudentViews.Exceptions;
using Ken.Portal.Web.Services.StudentViews;
using Ken.Portal.Web.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Ken.Portal.Web.Views.Components
{
    public partial class StudentRegistrationComponent : ComponentBase
    {
        [Inject]
        public IStudentViewService StudentViewService { get; set; }

        public ComponentState State { get; set; }
        public StudentRegistrationComponent Exception { get; set; }
        public StudentView StudentView { get; set; }
        public TextBoxBase StudentIdentityTextBox { get; set; }
        public TextBoxBase StudentFirstNameTextBox { get; set; }
        public TextBoxBase StudentMiddleNameTextBox { get; set; }
        public TextBoxBase StudentLastNameTextBox { get; set; }
        public DropDownBase<StudentViewGender> StudentGenderDropDown { get; set; }
        public DatePickerBase DateOfBirthPicker { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public LabelBase ErrorLabel { get; set; }

        protected override void OnInitialized()
        {
            this.StudentView = new StudentView();
            this.State = ComponentState.Content;
        }

        public async void RegisterStudentAsync()
        {
            try
            {
                await this.StudentViewService.AddStudentViewAsync(this.StudentView);
            }
            catch (StudentViewValidationException studentViewValidationException)
            {
                string validationMessage =
                    studentViewValidationException.InnerException.Message;

                this.ErrorLabel.SetValue(validationMessage);
            }
            catch (StudentViewDependencyValidationException dependencyValidationException)
            {
                string validationMessage =
                    dependencyValidationException.InnerException.Message;

                this.ErrorLabel.SetValue(validationMessage);
            }
            catch (StudentViewDependencyException studentViewDependencyException)
            {
                string validationMessage =
                    studentViewDependencyException.Message;

                this.ErrorLabel.SetValue(validationMessage);
            }
            catch (StudentViewServiceException studentViewServiceException)
            {
                string validationMessage =
                    studentViewServiceException.Message;

                this.ErrorLabel.SetValue(validationMessage);
            }
        }
    }
}
