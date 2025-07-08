//
// This file manually written from cef/include/internal/cef_types.h
//

using System;
using System.Runtime.InteropServices;
using Xilium.CefGlue.Interop;

namespace Xilium.CefGlue;

internal unsafe struct cef_task_info_t
{
    public long id;
    public CefTaskType type;
    public int is_killable;
    public cef_string_t title;
    public double cpu_usage;
    public int number_of_processors;
    public long memory;
    public long gpu_memory;
    public int is_gpu_memory_inflated;

    public static void Free(cef_task_info_t* self)
    {
        libcef.string_clear(&self->title);
    }
}
