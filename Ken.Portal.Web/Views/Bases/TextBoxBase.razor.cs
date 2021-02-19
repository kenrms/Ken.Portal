using Microsoft.AspNetCore.Components;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class TextBoxBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }
    }
}
