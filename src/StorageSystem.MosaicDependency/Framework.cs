using System;
using CareFusion.Mosaic.Core.Components;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.DB;
using CareFusion.Mosaic.Native;
using System.Threading;
using CareFusion.Mosaic.Core.Environment;
using System.Reflection;
using System.Diagnostics;

namespace CareFusion.Mosaic
{
    /// <summary>
    /// The Mosaic framework class itself -> required to start and stop Mosaic.
    /// </summary>
    public class Framework
    {
        #region Constants

        /// <summary>
        /// The component ID of Mosaic
        /// </summary>
        public const int MosaicComponentID = 1;

        #endregion

        #region Members

        /// <summary>
        /// Holds the instance of the active Mosaic database set.
        /// </summary>
        private DatabaseSet _dbSet = new DatabaseSet();

        /// <summary>
        /// Holds the instance of the active Mosaic component manager.
        /// </summary>
        //private ComponentManager _componentManager = new ComponentManager();

        /// <summary>
        /// Holds a flag which indicates whether a Mosaic shutdown is currently running.
        /// </summary>
        private static int _isShutdownRunning = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Checks whether this application is running as Windows service.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the application is running as service;<c>false</c> otherwise.
        /// </returns>
        public static bool IsRunningAsService
        {
            get
            {
                IntPtr hProcessToken = IntPtr.Zero;

                try
                {
                    if (Advapi32.OpenProcessToken(Kernel32.GetCurrentProcess(),
                                                  Advapi32.TOKEN_QUERY,
                                                  out hProcessToken) == false)
                    {
                        return false;
                    }

                    uint sessionId = 0;
                    uint returnedLength = 0;

                    if (Advapi32.GetTokenInformation(hProcessToken,
                                                     Advapi32.TOKEN_INFORMATION_CLASS.TokenSessionId,
                                                     out sessionId,
                                                     sizeof(uint),
                                                     out returnedLength) == false)
                    {
                        return false;
                    }

                    return (sessionId == 0) && (Environment.OSVersion.Version.Major > 5);
                }
                finally
                {
                    if (hProcessToken != IntPtr.Zero)
                    {
                        Kernel32.CloseHandle(hProcessToken);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether a Mosaic shutdown is currently running.
        /// </summary>
        public static bool IsShutdownRunning
        {
            get {  return _isShutdownRunning > 0; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the Mosaic framework and all related sub components.
        /// </summary>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Start()
        {
            this.Info("Mosaic starts ...");

            var mosaic = Assembly.GetExecutingAssembly();
            var mosaicVersion = FileVersionInfo.GetVersionInfo(mosaic.Location);

            this.Info("Executing '{0}' with version '{1}'.", mosaic.Location, mosaicVersion.ProductVersion);

            Interlocked.Exchange(ref _isShutdownRunning, 0);

            if (_dbSet.Initialize() == false)
            {
                return false;
            }

            /*if (_componentManager.Initialize(_dbSet) == false)
            {
                return false;
            }*/

            this.Trace("Mosaic started.");
            return true;
        }

        /// <summary>
        /// Stops the Mosaic framework and all related sub components.
        /// </summary>
        public void Stop()
        {
            this.Trace("Mosaic stops...");

            try
            {
                Interlocked.Exchange(ref _isShutdownRunning, 1);
                //_componentManager.Cancel();
                //_componentManager.Dispose();
                _dbSet.Dispose();
            }
            catch (Exception ex)
            {
                this.Error("Stopping Mosaic failed!", ex);
            }

            this.Trace("Mosaic stopped.");
        }

        

        #endregion
    }
}
