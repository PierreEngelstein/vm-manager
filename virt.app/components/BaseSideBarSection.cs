using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorDesktopApp
{
        public abstract class BaseSideBarSection : ComponentBase
        {
                [Parameter]
                public string str { get; set; }
        }
}