using Xilium.CefGlue.Interop;

namespace Xilium.CefGlue;

public class CefTaskInfo
{
    public long Id;
    public CefTaskType Type;
    public bool IsKillable;
    public string Title;
    public double CpuUsage;
    public int NumberOfProcessors;
    public long Memory;
    public long GpuMemory;
    public bool IsGpuMemoryInflated;

    internal static unsafe CefTaskInfo FromNative(cef_task_info_t* native)
    {
        var result = new CefTaskInfo();
        result.Id = native->id;
        result.Type = native->type;
        result.IsKillable = native->is_killable != 0;
        result.Title = cef_string_t.ToString(&native->title);
        result.CpuUsage = native->cpu_usage;
        result.NumberOfProcessors = native->number_of_processors;
        result.Memory = native->memory;
        result.GpuMemory = native->gpu_memory;
        result.IsGpuMemoryInflated = native->is_gpu_memory_inflated != 0;
        return result;
    }
}