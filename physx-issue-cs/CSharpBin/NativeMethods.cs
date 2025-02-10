using System.IO.Pipes;

namespace CsBindgen
{
    public unsafe partial struct PxController
    {
#pragma warning disable CS0169
        private void* ptr;
#pragma warning restore CS0169
    }
    public static class NativeBindings
    {
        public static LayoutInfo DeterminLayoutRust()
        {
            unsafe
            {
                return NativeMethods.determin_layout();
            }
        }
    }

}