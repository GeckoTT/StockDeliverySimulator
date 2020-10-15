using System;
using System.IO;
using System.Reflection;
using Rowa.Lib.Log;

namespace CareFusion.Mosaic.Core.Logging
{
    /// <summary>
    /// Class which implements the globally used application log functionality.
    /// </summary>
    public class ApplicationLog
    {
        #region Constants

        /// <summary>
        /// The log4net configuration file name for the Mosaic windows service process.
        /// </summary>
        private const string LogConfigFile = "RowaLogConfig.xml";

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the application log with the specified log type.
        /// </summary>
        public static void Initialize()
        {
            try
            {
                Environment.Directories.CreateDataDirectory();
                var logConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), LogConfigFile);

                if ((string.IsNullOrEmpty(logConfigPath)) ||
                    (File.Exists(logConfigPath) == false))
                {
                    return;
                }

                LogManager.Initialize("Mosaic", "Mosaic", LogConfigFile);
            }
            catch (Exception)
            {
            }            
        }

        /// <summary>
        /// Processes cleanup of the logging engine.
        /// </summary>
        public static void Cleanup()
        {
            LogManager.Cleanup();
        }

        #endregion
    }
}
