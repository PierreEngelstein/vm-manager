using VirtManager.Core;
using System;
namespace VirtManager
{
        public enum vmState
        {
                running = 0,
                idle = 1,
                paused = 2,
                inShutdown = 3,
                shutoff = 4,
                crashed = 5,
                pmsuspended = 6
        }

        public class VirtualMachine
        {
                public VirtualMachine(string name)
                {
                        Name = name;
                        if(Exists(Name))
                        {
                                // Fill in the information
                        }else
                        {
                                // Create an empty virtual machine object that will be created later
                        }
                }

                public void Create()
                {

                }

                public static bool Exists(string name)
                {
                        CommandOutput output = ShellExecuter.ExecuteBash("virsh list --all | grep " + name);
                        if(!string.IsNullOrEmpty(output.StandardError))
                                throw new InvalidOperationException("Something went wrong with the command 'virsh list --all | grep " + name);
                        return output.StandardOutput != string.Empty;
                }

                public override string ToString()
                {
                        string res = "Virtual Machine [name=" + Name + ", state=" + State.ToString("G") + "]";
                        return res;
                }

                public string Name{ get; set; }
                public int Id { get; set; }
                public vmState State { get; set; }
                public uint Memory { get; set; }
                public uint CurrentMemory { get; set; }
                public uint VCpu { get; set; }

        }
}