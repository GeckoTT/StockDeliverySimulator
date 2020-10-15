using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CareFusion.Mosaic.Native
{
    /// <summary>
    /// Class which contains all function import definitions of the shell32.dll.
    /// </summary>
    public static class Shell32
    {
        #region Enums

        /// <summary>
        /// Represents the different supported directory classes.
        /// </summary>
        public enum CSIDL
        {
            COMMON_STARTMENU = 0x0016,
            COMMON_PROGRAMS = 0x0017,
            COMMON_STARTUP = 0x0018
        }

        #endregion

        #region Function Imports

        /// <summary>
        /// Retrieves the path of a special folder, identified by its CSIDL.
        /// </summary>
        /// <param name="hwndOwner">Not used.</param>
        /// <param name="lpszPath">
        /// A pointer to a null-terminated string that receives the drive and path of the specified folder. 
        /// This buffer must be at least MAX_PATH characters in size.
        /// </param>
        /// <param name="nFolder">A CSIDL that identifies the folder of interest.</param>
        /// <param name="fCreate">Indicates whether the folder should be created if it does not already exist. </param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, CSIDL nFolder, bool fCreate);

        #endregion
    }
}
