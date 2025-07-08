//
// This file manually written from:
//     cef/include/internal/cef_types_win.h.
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    internal struct cef_window_info_t
    {
    }

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_window_info_t_windows
    {
        // Standard parameters required by CreateWindowEx()
        public uint ex_style;
        public cef_string_t window_name;
        public uint style;
        public cef_rect_t bounds;
        public IntPtr parent_window;
        public IntPtr menu;
        public int windowless_rendering_enabled;
        public int shared_texture_enabled;
        public int external_begin_frame_enabled;
        public IntPtr window;
        public CefRuntimeStyle runtime_style;

        #region Alloc & Free
        public static cef_window_info_t_windows* Alloc()
        {
            var ptr = (cef_window_info_t_windows*)NativeMemory.AllocZeroed((nuint)sizeof(cef_window_info_t_windows));
            return ptr;
        }

        public static void Free(cef_window_info_t_windows* ptr)
        {
            if (ptr != null)
            {
                libcef.string_clear(&ptr->window_name);
                NativeMemory.Free(ptr);
            }
        }
        #endregion
    }

    internal unsafe struct cef_window_info_t_linux
    {
        public cef_string_t window_name;
        public cef_rect_t bounds;
        public IntPtr parent_window;
        public int windowless_rendering_enabled;
        public int shared_texture_enabled;
        public int external_begin_frame_enabled;
        public IntPtr window;
        public CefRuntimeStyle runtime_style;

        #region Alloc & Free
        public static cef_window_info_t_linux* Alloc()
        {
            var ptr = (cef_window_info_t_linux*)NativeMemory.AllocZeroed((nuint)sizeof(cef_window_info_t_linux));
            return ptr;
        }

        public static void Free(cef_window_info_t_linux* ptr)
        {
            if (ptr != null)
            {
                libcef.string_clear(&ptr->window_name);
                NativeMemory.Free(ptr);
            }
        }
        #endregion
    }

    internal unsafe struct cef_window_info_t_mac
    {
        public cef_string_t window_name;
        public cef_rect_t bounds;
        public int hidden;
        public IntPtr parent_view;
        public int windowless_rendering_enabled;
        public int shared_texture_enabled;
        public int external_begin_frame_enabled;
        public IntPtr view;
        public CefRuntimeStyle runtime_style;

        #region Alloc & Free
        public static cef_window_info_t_mac* Alloc()
        {
            var ptr = (cef_window_info_t_mac*)NativeMemory.AllocZeroed((nuint)sizeof(cef_window_info_t_mac));
            return ptr;
        }

        public static void Free(cef_window_info_t_mac* ptr)
        {
            if (ptr != null)
            {
                libcef.string_clear(&ptr->window_name);
                NativeMemory.Free(ptr);
            }
        }
        #endregion
    }

}
