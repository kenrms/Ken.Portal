using FluentAssertions;
using Ken.Portal.Web.Models.Basics;
using Ken.Portal.Web.Views.Components;
using Xunit;

namespace Ken.Portal.Web.Tests.Unit.Components
{
    public partial class StudentFormComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given . when
            var initialStudentFormComponent = new StudentFormComponent();

            // then
            initialStudentFormComponent.StudentNameTextBox.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedState = ComponentState.Content;

            // when
            this.renderedStudentFormComponent = RenderComponent<StudentFormComponent>();

            // then
            this.renderedStudentFormComponent.Instance.State
                .Should().BeEquivalentTo(expectedState);

            this.renderedStudentFormComponent.Instance.StudentNameTextBox
                .Should().NotBeNull();

            this.renderedStudentFormComponent.Instance.StudentNameTextBox.PlaceHolder
                .Should().BeEquivalentTo("Name");
        }
    }
}
