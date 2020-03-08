using Microsoft.AspNetCore.Components;

namespace BlazorDesktopApp
{
        public abstract class BaseVirtualMachineMenu : ComponentBase
        {
                public string Name { get; set; } = "";

                public override string ToString()
                {
                        return Name;
                }
        }
}