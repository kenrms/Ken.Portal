using Microsoft.AspNetCore.Components;
using System;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class ButtonBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

        public void Click() => OnClick.Invoke();
    }
}
