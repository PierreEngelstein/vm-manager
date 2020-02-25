using System.Collections.Generic;
using System;
namespace VirtManager.Objects
{
        public class OsType
        {
                public string arch { get; set; }
                public string machine { get; set; }
                public type_enum type { get; set; } = type_enum.hvm;
                public string ToXml()
                {
                        string res = "<type";
                        if(!string.IsNullOrEmpty(arch))
                                res += " arch='" + arch + "'";
                        if(!string.IsNullOrEmpty(machine))
                                res += " machine='" + machine + "'";
                        res += ">" + type.ToString("G") + "</type>";
                        return res;
                }
        }
        public class Loader
        {
                public yes_no Readonly { get; set; } = yes_no.no;
                public yes_no Secure { get; set; } = yes_no.yes;
                public loader_type Type { get; set; }
                public String Path { get; set; } = "";
                public string ToXml()
                {
                        string res = "<loader readonly='" + Readonly.ToString("G") 
                                         + "' secure='" + Secure.ToString("G") 
                                         + "' type='" + Type.ToString("G") 
                                         + "'>" + Path + "</loader>";
                        return res;
                }

        }
        public class Os
        {
                public Firmware Firmware { get; set; } = Firmware.efi;
                public OsType type { get; set; }
                public Loader Loader { get; set; } = null;
                public List<boot_enum> boots { get; set; } = new List<boot_enum>();
                public string ToXml()
                {
                        string res = "<os firmware='" + Firmware.ToString("G") +"'>\n" + type.ToXml() + "\n";
                        if(Loader != null)
                                res += Loader.ToXml() + "\n";
                        foreach(boot_enum be in boots)
                        {
                                res += "<boot dev='" + be.ToString("G") + "'/>\n";
                        }
                        res += "</os>";
                        return res;
                }
        }
}