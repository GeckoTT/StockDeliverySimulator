using System;
using System.Runtime.InteropServices;

namespace CareFusion.Mosaic.Native
{
    /// <summary>
    /// Class which contains all function import definitions of the user32.dll.
    /// </summary>
    public static class User32
    {
        #region Constants

        /// <summary>
        /// Places the window at the top of the Z order.
        /// </summary>
        public static readonly IntPtr HWND_TOP = IntPtr.Zero;

        /// <summary>
        /// Places the window at the bottom of the Z order.
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        public const uint SWP_NOSIZE = 0x0001;

        /// <summary>
        /// Retains the current position (ignores X and Y parameters).
        /// </summary>
        public const uint SWP_NOMOVE = 0x0002;

        /// <summary>
        /// Displays the window.
        /// </summary>
        public const uint SWP_SHOWWINDOW = 0x0040;

        /// <summary>
        /// Flag which hides the specified window.
        /// </summary>
        public const uint SW_HIDE = 0;

        /// <summary>
        /// Flag which shows the specified window.
        /// </summary>
        public const uint SW_SHOW = 5;

        /// <summary>
        /// Flag which shows the specified window.
        /// </summary>
        public const uint SW_SHOWNORMAL = 1;

        #region Window Messages

        /// <summary>
        /// Message to close a window.
        /// </summary>
        public const uint WM_CLOSE = 0x0010;

        /// <summary>
        /// Message to destroy a window.
        /// </summary>
        public const uint WM_DESTROY = 0x0002;

        /// <summary>
        /// Indicates a request to terminate an application.
        /// </summary>
        public const uint WM_QUIT = 0x0012;

        #endregion

        #endregion

        #region Types

        /// <summary>
        /// Contains location information of a window.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        /// <summary>
        /// Contains the rectangle information of a window.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT 
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        
        /// <summary>
        /// Contains window placement information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public uint length;
            public uint flags;
            public uint showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        #endregion

        #region Function Imports

        /// <summary>
        /// Retrieves a handle to the desktop window. 
        /// The desktop window covers the entire screen. 
        /// The desktop window is the area on top of which other windows are painted. 
        /// </summary>
        /// <returns>The return value is a handle to the desktop window. </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. 
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hwnd">A handle to the window. </param>
        /// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
        /// <param name="x">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags.</param>
        /// <returns><c>true</c> if successful; <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="lpClassName">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Changes the parent window of the specified child window. 
        /// </summary>
        /// <param name="hWndChild">A handle to the child window.</param>
        /// <param name="hWndNewParent">A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose parent window handle is to be retrieved. </param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window. 
        /// </summary>
        /// <param name="hWnd">A handle to the window. </param>
        /// <param name="lpwndpl">A pointer to a WINDOWPLACEMENT structure that specifies the new show state and window positions.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window. 
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">A pointer to the WINDOWPLACEMENT structure that receives the show state and position information. </param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Minimizes (but does not destroy) the specified window. 
        /// </summary>
        /// <param name="hwnd">A handle to the window to be minimized. </param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool CloseWindow(IntPtr hwnd);

        /// <summary>
        /// Destroys the specified window. 
        /// </summary>
        /// <param name="hwnd">A handle to the window to be destroyed.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hwnd);

        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created 
        /// the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="Msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, uint wParam, uint lParam);

        #endregion
    }
}
