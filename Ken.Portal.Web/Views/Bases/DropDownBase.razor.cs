using Microsoft.AspNetCore.Components;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class DropDownBase<TEnum> : ComponentBase
    {
        [Parameter]
        public TEnum Value { get; set; }
    }
}
