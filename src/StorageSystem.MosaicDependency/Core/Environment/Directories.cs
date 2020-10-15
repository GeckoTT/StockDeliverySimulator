using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using Rowa.Lib.Log;

namespace CareFusion.Mosaic.Core.Environment
{
    /// <summary>
    /// Class which provides convenient access to the different Mosaic related directories.
    /// </summary>
    public static class Directories
    {
        #region Constants

        /// <summary>
        /// Default root directory to use in case that no program data directory is available.
        /// </summary>
        private const string DefaultDirectory = ".\\";

        /// <summary>
        /// Path of the fallback directory to use in case that no program data environment variable has been set.
        /// </summary>
        private const string FallbackDirectory = "C:\\ProgramData";

        /// <summary>
        /// Path of the data sub directory.
        /// </summary>
        private const string DataSubDirectory = "CareFusion\\Mosaic\\";

        /// <summary>
        /// Path of the sub directory which is used for log files.
        /// </summary>
        private const string LogSubDirectory = "Logs\\";

        /// <summary>
        /// Path of the sub directory which is used for video files.
        /// </summary>
        private const string VideoSubDirectory = "Videos\\";

        /// <summary>
        /// Path of the sub directory which is used for trashed video files.
        /// </summary>
        private const string VideoTrashSubDirectory = "Videos\\Trash\\";

        /// <summary>
        /// Path of the untit test related sub directory to prevent collisions with productive data.
        /// </summary>
        private const string UnitTestSubDirectory = "UnitTests\\";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the path of the Mosaic data directory.
        /// </summary>
        public static string DataDirectory
        {
            get
            {
                string programDataDirectory = string.Empty;

                try
                {
                    programDataDirectory = System.Environment.GetEnvironmentVariable("PROGRAMDATA");
                }
                catch (Exception)
                {
                }

                if (string.IsNullOrEmpty(programDataDirectory))
                {
                    try
                    {
                        if (Directory.Exists(FallbackDirectory) == false)
                        {
                            Directory.CreateDirectory(FallbackDirectory);
                        }

                        programDataDirectory = FallbackDirectory;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (string.IsNullOrEmpty(programDataDirectory))
                {
                    programDataDirectory = DefaultDirectory;
                }

                string directory = Path.Combine(programDataDirectory, DataSubDirectory);

                if (Assembly.GetEntryAssembly() == null)
                {
                    directory = Path.Combine(directory, UnitTestSubDirectory);
                }

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                    PatchDirectoryAccessRights(directory);
                }

                if (directory.EndsWith("\\") == false)
                {
                    directory += "\\";
                }

                return directory;
            }
        }

        /// <summary>
        /// Gets the path of the Mosaic log directory.
        /// </summary>
        public static string LogDirectory
        {
            get
            {
                string directory = string.Format("{0}{1}", Directories.DataDirectory, LogSubDirectory);

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                

                return directory;
            }
        }

        /// <summary>
        /// Gets the path of the video directory.
        /// </summary>
        public static string VideoDirectory
        {
            get
            {
                string directory = string.Format("{0}{1}", Directories.DataDirectory, VideoSubDirectory);

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                return directory;
            }
        }

        /// <summary>
        /// Gets the path of the directory for trashed videos.
        /// </summary>
        public static string VideoTrashDirectory
        {
            get
            {
                string directory = string.Format("{0}{1}", Directories.DataDirectory, VideoTrashSubDirectory);

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                return directory;
            }
        }

        #endregion


        /// <summary>
        /// Ensures that the Mosaic data directory was created.
        /// </summary>
        public static void CreateDataDirectory()
        {
            string dataDirectory = DataDirectory;

            if (Directory.Exists(dataDirectory) == false)
            {
                Directory.CreateDirectory(dataDirectory);
                PatchDirectoryAccessRights(dataDirectory);
            }
        }


        #region Utility Methods

        /// <summary>
        /// Patches the directory access rights for the specified directory to allow full access for network service.
        /// </summary>
        /// <param name="directoryPath">The directory path to patch.</param>
        private static void PatchDirectoryAccessRights(string directoryPath)
        {
            // directory access rights patching is only used for Windows Vista or higher

            if (System.Environment.OSVersion.Version.Major > 5)
            {
                var accessRuleSvc = new FileSystemAccessRule(InstallUtil.GetNetworkServiceName(),
                                                             FileSystemRights.FullControl,
                                                             InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                                             PropagationFlags.None,
                                                             AccessControlType.Allow);

                var accessRuleUsr = new FileSystemAccessRule(System.Environment.UserName,
                                                             FileSystemRights.FullControl,
                                                             InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                                             PropagationFlags.None,
                                                             AccessControlType.Allow);

                var directoryInfo = new DirectoryInfo(directoryPath);
                var directorySecurity = directoryInfo.GetAccessControl();

                directorySecurity.AddAccessRule(accessRuleSvc);
                directorySecurity.AddAccessRule(accessRuleUsr);
                directoryInfo.SetAccessControl(directorySecurity);
            }
        }

        #endregion
    }
}
