//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_task_type_t.
//

namespace Xilium.CefGlue;

public enum CefTaskType
{
    Unknown = 0,
    Browser,
    Gpu,
    Zygote,
    Utility,
    Renderer,
    Extension,
    Guest,
    Plugin,
    SandboxHelper,
    DedicatedWorker,
    SharedWorker,
    ServiceWorker,
}