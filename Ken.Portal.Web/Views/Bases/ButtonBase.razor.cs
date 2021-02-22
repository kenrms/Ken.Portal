using Microsoft.AspNetCore.Components;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class ButtonBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }
    }
}
