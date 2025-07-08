//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_axis_alignment_t.
//
namespace Xilium.CefGlue
{
    using System;

    /// <summary>
    /// Specifies where along the main axis the CefBoxLayout child views should be
    /// laid out.
    /// </summary>
    public enum CefAxisAlignment
    {
        /// <summary>
        /// Child views will be left-aligned.
        /// </summary>
        Start,

        /// <summary>
        /// Child views will be center-aligned.
        /// </summary>
        Center,

        /// <summary>
        /// Child views will be right-aligned.
        /// </summary>
        End,

        /// <summary>
        /// Child views will be stretched to fit.
        /// </summary>
        Stretch,
    }
}
