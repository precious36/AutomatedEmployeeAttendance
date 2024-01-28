using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_Desktop_App.Enums
{
    class StructWrapper : IDisposable
    {
        public IntPtr Ptr { get; private set; }

        public StructWrapper(Type obj)
        {
            if (Ptr != null)
            {
                Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj)*2);
               // Marshal.StructureToPtr(obj, Ptr, false);
            }
            else
            {
                Ptr = IntPtr.Zero;
            }
        }

        ~StructWrapper()
        {
            if (Ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Ptr);
                Ptr = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Ptr);
            Ptr = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

        public static implicit operator IntPtr(StructWrapper w)
        {
            return w.Ptr;
        }
    }
}
