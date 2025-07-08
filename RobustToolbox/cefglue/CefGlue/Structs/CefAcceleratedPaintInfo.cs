using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Xilium.CefGlue;

// Layout differs per OS.
// Native type is cef_accelerated_paint_info_t

[StructLayout(LayoutKind.Explicit)]
public struct CefAcceleratedPaintInfo
{
    [FieldOffset(0)] internal CefAcceleratedPaintWindowsInfo _windows;
    [FieldOffset(0)] internal CefAcceleratedPaintMacInfo _mac;
    [FieldOffset(0)] internal CefAcceleratedPaintLinuxInfo _linux;

    [SupportedOSPlatform("windows")]
    [UnscopedRef]
    public readonly ref readonly CefAcceleratedPaintWindowsInfo GetForWindows()
    {
        if (!OperatingSystem.IsWindows())
            throw new InvalidOperationException();

        return ref _windows;
    }

    [SupportedOSPlatform("macos")]
    [UnscopedRef]
    public readonly ref readonly CefAcceleratedPaintMacInfo GetForMac()
    {
        if (!OperatingSystem.IsWindows())
            throw new InvalidOperationException();

        return ref Unsafe.As<CefAcceleratedPaintInfo, CefAcceleratedPaintMacInfo>(ref Unsafe.AsRef(in this));
    }

    [SupportedOSPlatform("linux")]
    [UnscopedRef]
    public readonly ref readonly CefAcceleratedPaintLinuxInfo GetForLinux()
    {
        if (!OperatingSystem.IsWindows())
            throw new InvalidOperationException();

        return ref Unsafe.As<CefAcceleratedPaintInfo, CefAcceleratedPaintLinuxInfo>(ref Unsafe.AsRef(in this));
    }
}

public unsafe struct CefAcceleratedPaintWindowsInfo
{
    /// <summary>
    /// Handle for the shared texture. The shared texture is instantiated
    /// without a keyed mutex.
    /// </summary>
    /// <remarks>
    /// This is a <c>HANDLE</c>.
    /// </remarks>
    public void* SharedTextureHandle;

    /// <summary>
    /// The pixel format of the texture.
    /// </summary>
    public CefColorType Format;
}

public unsafe struct CefAcceleratedPaintMacInfo
{
    /// <summary>
    /// Handle for the shared texture IOSurface.
    /// </summary>
    /// <remarks>
    /// This is a <c>HANDLE</c>.
    /// </remarks>
    public void* SharedTextureHandle;

    /// <summary>
    /// The pixel format of the texture.
    /// </summary>
    public CefColorType Format;
}

public struct CefAcceleratedPaintLinuxInfo
{
    public const int AcceleratedPaintMaxPlanes = 4;

    /// <summary>
    /// Planes of the shared texture, usually file descriptors of dmabufs.
    /// </summary>
    public CefAcceleratedPaintLinuxNativePixmapPlanes Planes;

    /// <summary>
    /// Plane count.
    /// </summary>
    public int PlaneCount;

    /// <summary>
    /// Modifier could be used with EGL driver.
    /// </summary>
    public ulong Modifier;

    /// <summary>
    /// The pixel format of the texture.
    /// </summary>
    public CefColorType Format;
}

[InlineArray(CefAcceleratedPaintLinuxInfo.AcceleratedPaintMaxPlanes)]
public struct CefAcceleratedPaintLinuxNativePixmapPlanes
{
    private CefAcceleratedPaintLinuxNativePixmapPlaneInfo _element0;
}

public struct CefAcceleratedPaintLinuxNativePixmapPlaneInfo
{
    ///
    /// The strides and offsets in bytes to be used when accessing the buffers via
    /// a memory mapping. One per plane per entry. Size in bytes of the plane is
    /// necessary to map the buffers.
    ///
    public uint Stride;
    public ulong Offset;
    public ulong Size;

    ///
    /// File descriptor for the underlying memory object (usually dmabuf).
    ///
    public int Fd;
}