using WebWindows.Blazor;
using System;
using VirtManager.Core;
using VirtManager;
using System.Collections.Generic;

namespace BlazorDesktopApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Virtual Machines Manager", "wwwroot/index.html");
        }
    }
}
