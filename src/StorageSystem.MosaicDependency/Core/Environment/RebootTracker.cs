using Microsoft.Win32;
using System;

namespace CareFusion.Mosaic.Core.Environment
{
    /// <summary>
    /// Class which provides functionality to track and detect a PC reboot.
    /// </summary>
    public static class RebootTracker
    {
        #region Constants

        /// <summary>
        /// The registry key name to use when storing the tracker value.
        /// </summary>
        private const string TrackerRegKeyName = "Software\\Rowa\\Mosaic";

        /// <summary>
        /// The registry value name to use when storing the tracker value.
        /// </summary>
        private const string TrackerRegValueName = "RebootDone";

        #endregion

        #region Members

        /// <summary>
        /// The flag whether an reboot has been detected.
        /// </summary>
        private static bool _rebootDone = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether a machine reboot has been detected.
        /// </summary>
        public static bool RebootDone
        {
            get { return _rebootDone; }
        }

        #endregion

        /// <summary>
        /// Initializes the <see cref="RebootTracker"/> class.
        /// </summary>
        static RebootTracker()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(TrackerRegKeyName))
                {
                    if (key == null)
                        return;

                    if (key.GetValue(TrackerRegValueName) != null)
                        _rebootDone = true;
                }

                Registry.CurrentUser.DeleteSubKey(TrackerRegKeyName);
            }
            catch (Exception)
            {  
            }
        }
        
        /// <summary>
        /// Sets the tracking cookie for a machine reboot.
        /// </summary>
        public static void TrackReboot()
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(TrackerRegKeyName))
                {
                    if (key == null)
                        return;

                    key.SetValue(TrackerRegValueName, true);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
