using Microsoft.AspNetCore.Components;
using System;

namespace Ken.Portal.Web.Views.Bases
{
    public partial class DatePickerBase : ComponentBase
    {
        [Parameter]
        public DateTimeOffset Value { get; set; }

        public void SetValue(DateTimeOffset value) =>
            this.Value = value;
    }
}
