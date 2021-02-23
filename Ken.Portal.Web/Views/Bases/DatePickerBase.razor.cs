﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class DatePickerBase : ComponentBase
    {
        [Parameter]
        public DateTimeOffset Value { get; set; }

        [Parameter]
        public EventCallback<DateTimeOffset> ValueChanged { get; set; }

        public void SetValue(DateTimeOffset value) =>
            this.Value = value;

        private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        {
            this.Value = DateTimeOffset.Parse(changeEventArgs.Value.ToString());

            return ValueChanged.InvokeAsync(this.Value);
        }
    }
}
