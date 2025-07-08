//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_resultcode_t.
//

namespace Xilium.CefGlue;

public enum CefResultcode
{
    NormalExit,

    /// Process was killed by user or system.
    Killed,

    /// Process hung.
    Hung,

    /// A bad message caused the process termination.
    KilledBadMessage,

    /// The GPU process exited because initialization failed.
    GpuDeadOnArrival,

    // The following values should be kept in sync with Chromium's
    // chrome::ResultCode type. Unused chrome values are excluded.

    ChromeFirst,

    /// A critical chrome file is missing.
    MissingData = 7,

    /// Command line parameter is not supported.
    UnsupportedParam = 13,

    /// The profile was in use on another host.
    ProfileInUse = 21,

    /// Failed to pack an extension via the command line.
    PackExtensionError = 22,

    /// The browser process exited early by passing the command line to another
    /// running browser.
    NormalExitProcessNotified = 24,

    /// A browser process was sandboxed. This should never happen.
    InvalidSandboxState = 31,

    /// Cloud policy enrollment failed or was given up by user.
    CloudPolicyEnrollmentFailed = 32,

    /// The GPU process was terminated due to context lost.
    GpuExitOnContextLost = 34,

    /// An early startup command was executed and the browser must exit.
    NormalExitPackExtensionSuccess = 36,

    /// The browser process exited because system resources are exhausted. The
    /// system state can't be recovered and will be unstable.
    SystemResourceExhausted = 37,

    ChromeLast = 38,

    // The following values should be kept in sync with Chromium's
    // sandbox::TerminationCodes type.

    SandboxFatalFirst = 7006,

    /// Windows sandbox could not set the integrity level.
    SandboxFatalIntegrity = SandboxFatalFirst,

    /// Windows sandbox could not lower the token.
    SandboxFatalDroptoken,

    /// Windows sandbox failed to flush registry handles.
    SandboxFatalFlushandles,

    /// Windows sandbox failed to forbid HCKU caching.
    SandboxFatalCachedisable,

    /// Windows sandbox failed to close pending handles.
    SandboxFatalClosehandles,

    /// Windows sandbox could not set the mitigation policy.
    SandboxFatalMitigation,

    /// Windows sandbox exceeded the job memory limit.
    SandboxFatalMemoryExceeded,

    /// Windows sandbox failed to warmup.
    SandboxFatalWarmup,

    // Windows sandbox broker terminated in shutdown.
    SandboxFatalBrokerShutdownHung,
}