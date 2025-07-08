using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xilium.CefGlue.Interop;

namespace Xilium.CefGlue;

/// <summary>
/// Class that facilitates managing the browser-related tasks.
/// The methods of this class may only be called on the UI thread.
/// </summary>
public sealed unsafe partial class CefTaskManager
{
    /// <summary>
    /// Returns the global task manager object.
    /// Returns nullptr if the method was called from the incorrect thread.
    /// </summary>
    public static CefTaskManager Get() => FromNative(cef_task_manager_t.get());

    /// <summary>
    /// Returns the number of tasks currently tracked by the task manager.
    /// Returns 0 if the method was called from the incorrect thread.
    /// </summary>
    public nuint TasksCount => cef_task_manager_t.get_tasks_count(_self);

    /// <summary>
    /// Gets the list of task IDs currently tracked by the task manager. Tasks
    /// that share the same process id will always be consecutive. The list will
    /// be sorted in a way that reflects the process tree: the browser process
    /// will be first, followed by the gpu process if it exists. Related processes
    /// (e.g., a subframe process and its parent) will be kept together if
    /// possible. Callers can expect this ordering to be stable when a process is
    /// added or removed. The task IDs are unique within the application lifespan.
    /// Returns false if the method was called from the incorrect thread.
    /// </summary>
    /// <param name="taskIds"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void GetTaskIdsList(List<long> taskIds)
    {
        var count = checked((int)TasksCount);

        CollectionsMarshal.SetCount(taskIds, count);
        var span = CollectionsMarshal.AsSpan(taskIds);

        var received_count = (nuint) count;
        fixed (long* taskIdsPtr = span)
        {
            var result = cef_task_manager_t.get_task_ids_list(_self, &received_count, taskIdsPtr);
            if (result != 1)
            {
                span.Clear();
                throw new InvalidOperationException("Called from wrong thread!");
            }
        }

        if (received_count < (nuint)count)
        {
            // I don't think this is possible but let's be safe.
            CollectionsMarshal.SetCount(taskIds, checked((int)received_count));
        }
    }

    /// <summary>
    /// Gets information about the task with |task_id|.
    /// Returns true if the information about the task was successfully
    /// retrieved and false if the |task_id| is invalid or the method was called
    /// from the incorrect thread.
    /// </summary>
    public bool GetTaskInfo(long taskId, out CefTaskInfo info)
    {
        cef_task_info_t taskInfo = new();
        var success = cef_task_manager_t.get_task_info(_self, taskId, &taskInfo);

        info = CefTaskInfo.FromNative(&taskInfo);
        return success != 0;
    }

    /// <summary>
    /// Attempts to terminate a task with |task_id|.
    /// Returns false if the |task_id| is invalid, the call is made from an
    /// incorrect thread, or if the task cannot be terminated.
    /// </summary>
    public bool KillTask(long taskId)
    {
        return cef_task_manager_t.kill_task(_self, taskId) != 0;
    }

    /// <summary>
    /// Returns the task ID associated with the main task for |browser_id|
    /// (value from CefBrowser::GetIdentifier). Returns -1 if |browser_id| is
    /// invalid, does not currently have an associated task, or the method was
    /// called from the incorrect thread.
    /// </summary>
    public long GetTaskIdForBrowserId(int browserId)
    {
        return cef_task_manager_t.get_task_id_for_browser_id(_self, browserId);
    }
}