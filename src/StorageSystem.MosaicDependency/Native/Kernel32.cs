using System;
using System.Runtime.InteropServices;

namespace CareFusion.Mosaic.Native
{
    /// <summary>
    /// Class which contains all function import definitions of the kernel32.dll.
    /// </summary>
    public static class Kernel32
    {
        #region Constants

        /// <summary>
        /// The standard output device. Initially, this is the active console screen buffer.
        /// </summary>
        public const int STD_OUTPUT_HANDLE = -11; 

        #endregion

        #region Types

        /// <summary>
        /// Defines the coordinates of a character cell in a console screen buffer. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD 
        {
            public short X;
            public short Y;
        }

        #endregion

        #region Function Imports

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool AllocConsole();

        /// <summary>
        /// Sets the title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">The string to be displayed in the title bar of the console window. </param>
        /// <returns>
        ///   <c>true</c> if successful;<c>false</c> otherwise.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool SetConsoleTitle(string lpConsoleTitle);

        /// <summary>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">The standard device.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified device, 
        /// or a redirected handle set by a previous call to SetStdHandle.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        /// <summary>
        /// Retrieves the size of the largest possible console window, based on the current font and the size of the display.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer.</param>
        /// <returns>
        /// If the function succeeds, the return value is a COORD structure that specifies the number of character 
        /// cell rows (X member) and columns (Y member) in the largest possible console window. 
        /// Otherwise, the members of the structure are zero.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern COORD GetLargestConsoleWindowSize(IntPtr hConsoleOutput);

        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>
        /// The return value is a handle to the window used by the console associated with the 
        /// calling process or NULL if there is no such associated console.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();

        /// <summary>
        /// Frees the specified local memory object and invalidates its handle.
        /// </summary>
        /// <param name="hMem">A handle to the local memory object.</param>
        /// <returns>If the function succeeds, the return value is IntPtr.Zero.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hMem);

        /// <summary>
        /// Retrieves a pseudo handle for the current process.
        /// </summary>
        /// <returns>
        /// The return value is a pseudo handle to the current process.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern IntPtr GetCurrentProcess();

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">
        /// A valid handle to an open object.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful; <c>false</c> otherwise.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern bool CloseHandle(IntPtr hObject);

        #endregion
    }
}
