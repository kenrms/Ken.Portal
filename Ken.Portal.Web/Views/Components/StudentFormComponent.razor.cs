using Ken.Portal.Web.Models.Basics;
using Ken.Portal.Web.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Ken.Portal.Web.Views.Components
{
    public partial class StudentFormComponent : ComponentBase
    {
        public TextBoxBase StudentNameTextBox { get; set; }
        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}
