using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using BlazorDesktopApp.Pages;
namespace BlazorDesktopApp
{
        public class BaseVirtualMachinesPanel : ComponentBase
        {
                [Parameter]
                public List<BaseVirtualMachineMenu> Menus { get; set; }
                protected BaseVirtualMachineMenu SelectedMenu { get; set; }

                /** CSS values as parameter **/
                [Parameter]
                public int sidePanelSizePx { get; set; }
                [Parameter]
                public int sidePanelMarginPx { get; set; }
                protected string sidePanelStr { get => sidePanelSizePx.ToString() + "px"; }
                protected string sidePanelMarginStr { get => sidePanelMarginPx.ToString() + "px";}

                protected override void OnInitialized()
                {
                        SelectedMenu = Menus[0];
                }

                protected void Select(int index)
                {
                        if(index < 0 || index > Menus.Count)
                        {
                                SelectedMenu = Menus[0]; 
                                return;
                        }
                        SelectedMenu = Menus[index];
                }

        }
}