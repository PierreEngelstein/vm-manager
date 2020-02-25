namespace VirtManager.Objects
{
        public enum type_enum
        {
                xen    = 0, // XEN PV
                linux  = 1, // XEN
                xenpvh = 2, // XEN PVH
                hvm    = 3, // Unmodified os
                exe    = 4, // Container-based virtualization
        }
        public enum boot_enum
        {
                fd = 0,
                hd = 1,
                cdrom = 2,
                network = 3
        }
        public enum yes_no
        {
                yes, no
        }

        public enum loader_type
        {
                rom, pflash
        }

        public enum Firmware
        {
                bios, efi
        }
}