//
// This file manually written from cef/include/internal/cef_types.h.
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_request_context_settings_t
    {
        public UIntPtr size;
        public cef_string_t cache_path;
        public int persist_session_cookies;
        public cef_string_t accept_language_list;
        public cef_string_t cookieable_schemes_list;
        public int cookieable_schemes_exclude_defaults;

        #region Alloc & Free
        public static cef_request_context_settings_t* Alloc()
        {
            var ptr = (cef_request_context_settings_t*)NativeMemory.AllocZeroed((nuint)sizeof(cef_request_context_settings_t));
            ptr->size = (nuint)sizeof(cef_request_context_settings_t);
            return ptr;
        }

        public static void Free(cef_request_context_settings_t* ptr)
        {
            NativeMemory.Free(ptr);
        }
        #endregion
    }
}
