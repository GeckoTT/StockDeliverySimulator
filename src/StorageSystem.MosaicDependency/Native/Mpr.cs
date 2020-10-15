using System.Runtime.InteropServices;

namespace CareFusion.Mosaic.Native
{
    /// <summary>
    /// Class which contains all function import definitions of the mpr.dll. 
    /// </summary>
    public static class Mpr
    {
        #region Constants

        /// <summary>
        /// The mapped resource can be of any type.
        /// </summary>
        public const uint RESOURCETYPE_ANY = 0x00000000;

        /// <summary>
        /// The mapping will be temporary.
        /// </summary>
        public const uint CONNECT_TEMPORARY = 0x00000004;

        /// <summary>
        /// Result for successful mapping.
        /// </summary>
        public const uint NO_ERROR = 0x00000000;

        /// <summary>
        /// Result if the network drive is already mapped.
        /// </summary>
        public const uint ERROR_ALREADY_ASSIGNED = 0x00000055;

        #endregion

        #region Types

        /// <summary>
        /// Structure which is required to define a drive and a network share to map.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        #endregion

        #region Function Imports

        /// <summary>
        /// The WNetAddConnection2 function makes a connection to a network resource and can redirect a local device to the network resource.
        /// </summary>
        /// <param name="lpNetResource">A pointer to a NETRESOURCE structure that specifies details of the proposed connection, such as information about the network resource, the local device, and the network resource provider.</param>
        /// <param name="lpPassword">A pointer to a constant null-terminated string that specifies a password to be used in making the network connection.</param>
        /// <param name="lpUsername">A pointer to a constant null-terminated string that specifies a user name for making the connection.</param>
        /// <param name="dwFlags">A set of connection options.</param>
        /// <returns>If the function succeeds, the return value is NO_ERROR.</returns>
        [DllImport("Mpr.dll", CharSet = CharSet.Auto)]
        public static extern uint WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, uint dwFlags);

        #endregion
    }
}
