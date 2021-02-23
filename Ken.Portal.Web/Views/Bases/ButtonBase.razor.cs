﻿using Microsoft.AspNetCore.Components;
using System;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class ButtonBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public void Click() => OnClick.Invoke();

        public void Disable() => this.IsDisabled = true;

        public void Enable() => this.IsDisabled = false;
    }
}
