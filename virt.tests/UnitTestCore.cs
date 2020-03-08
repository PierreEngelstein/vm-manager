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

        public class cA
        {
            public string param1 { get; set; }
        }

        public class coucou
        {
            public cA paramcA { get; set; }
        }

        [Fact]
        public void TestCopyOrRef()
        {
            cA a = new cA();
            a.param1 = "coucou";

            cA b = a;
            b.param1 = "nope";

            Console.WriteLine("{0}, {1}", a.param1, b.param1);

            coucou c = new coucou();
            c.paramcA = b;
            c.paramcA.param1 = "NO";
            Console.WriteLine("{0}, {1}", a.param1, b.param1);
        }
    }
}
