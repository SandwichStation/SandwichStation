namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    internal struct cef_main_args_t
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_main_args_t_windows
    {
        public IntPtr instance;

        #region Alloc & Free

        public static cef_main_args_t_windows* Alloc()
        {
            var ptr = (cef_main_args_t_windows*)NativeMemory.AllocZeroed((UIntPtr)sizeof(cef_main_args_t_windows));
            return ptr;
        }

        public static void Free(cef_main_args_t_windows* ptr)
        {
            NativeMemory.Free(ptr);
        }

        #endregion
    }

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_main_args_t_posix
    {
        public int argc;
        public byte** argv;

        #region Alloc & Free
        public static cef_main_args_t_posix* Alloc()
        {
            var ptr = (cef_main_args_t_posix*)NativeMemory.AllocZeroed((nuint)sizeof(cef_main_args_t_posix));
            return ptr;
        }

        public static void Free(cef_main_args_t_posix* ptr)
        {
            NativeMemory.Free(ptr);
        }
        #endregion
    }
}
