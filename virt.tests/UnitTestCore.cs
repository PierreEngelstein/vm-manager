using System;
using Xunit;
using VirtManager;
using VirtManager.Core;
using VirtManager.Objects;

namespace virt.tests
{
    public class UnitTestsCore
    {
        [Fact]
        public void TestCorrectOutput()
        {
            CommandOutput output = ShellExecuter.ExecuteBash("virsh list --all");
            Console.WriteLine(output);
            Assert.False(string.IsNullOrEmpty(output.StandardOutput));
            Assert.True(string.IsNullOrEmpty(output.StandardError));
        }

        [Fact]
        public void TestWrongOutput()
        {
            CommandOutput output = ShellExecuter.ExecuteBash("virsh list 123456");
            Console.WriteLine(output);
            Assert.True(string.IsNullOrEmpty(output.StandardOutput));
            Assert.False(string.IsNullOrEmpty(output.StandardError));
        }

        [Fact]
        public void TestExists()
        {
            Assert.True(VirtualMachine.Exists("debian10"));
            Assert.False(VirtualMachine.Exists("debian9"));
        }

        [Fact]
        public void Test()
        {
            Os os = new Os();
            os.type = new OsType(){
                arch = "x86_64",
                machine = "pc-q35-4.0"
            };
            os.Loader = new Loader()
            {
                Readonly = yes_no.yes,
                Secure = yes_no.yes,
                Type = loader_type.rom,
                Path = "/exemple/of/path"
            };
            os.boots.Add(boot_enum.hd);
            
            Console.WriteLine(os.ToXml());
        }
    }
}
