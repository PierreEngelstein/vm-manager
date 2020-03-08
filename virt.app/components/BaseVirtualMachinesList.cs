using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VirtManager;

namespace BlazorDesktopApp
{
        ///<summary>
        ///     Base component for displaying virtual machine lists
        ///</summary>
        public abstract class BaseVirtualMachinesList : ComponentBase
        {
                [Parameter]
                public VirtualMachine selectedMachine { get; set; }

                [Parameter]
                public List<VirtualMachine> vms { get; set; }
                [Parameter]
                public EventCallback<VirtualMachine> actionOnClickVMItem { get; set; }

                protected List<bool> vms_displayed { get; set; }

                protected override void OnInitialized()
                {
                        vms_displayed = new List<bool>();
                        foreach(VirtualMachine m in vms)
                                vms_displayed.Add(true);
                }
                
                protected void onClickVMItem(int index)
                {
                        if(index >= 0 && index < vms.Count)
                                actionOnClickVMItem.InvokeAsync(vms[index]);
                }

                protected async Task OnFiltered(ChangeEventArgs e)
                {
                        string selected = (string)e.Value;
                        vms_displayed = await Task.Run(() => vms.Select(vm => vm.Name.Contains(selected)).ToList());
                        await InvokeAsync(StateHasChanged);
                }
        }
}