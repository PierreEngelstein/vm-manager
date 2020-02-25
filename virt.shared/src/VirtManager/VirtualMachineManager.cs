using System.Collections.Generic;
using VirtManager.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace VirtManager
{
        public class VirtualMachineManager
        {
                public VirtualMachineManager()
                {

                }

                public async Task<IEnumerable<VirtualMachine>> GetAllMachines()
                {
                        IEnumerable<VirtualMachine> value = await Task.Run(() =>
                        {
                                List<VirtualMachine> machines = new List<VirtualMachine>();
                                string output = ShellExecuter.ExecuteBash("virsh list --all").StandardOutput;
                                if(string.IsNullOrEmpty(output))
                                        return machines;
                                
                                string[] lines = output.Split('\n');
                                for(int i = 0; i < lines.Length; i++)
                                {
                                        if(i < 2) continue;
                                        string[] elements  = lines[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                                        if(elements.Length < 3) continue;
                                        VirtualMachine current_machine = new VirtualMachine(elements[1]);
                                        switch(elements[2])
                                        {
                                                case "running": current_machine.State = vmState.running; break;
                                                case "idle": current_machine.State = vmState.idle; break;
                                                case "paused": current_machine.State = vmState.paused; break;
                                                case "in": current_machine.State = vmState.inShutdown; break;
                                                case "shut": current_machine.State = vmState.shutoff; break;
                                                case "crashed": current_machine.State = vmState.crashed; break;
                                                case "pmsuspended": current_machine.State = vmState.pmsuspended; break;
                                        }
                                        machines.Add(current_machine);
                                }
                                return machines;
                        });

                        return value;
                }
        }
}