using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CareFusion.Mosaic.Native;

namespace CareFusion.Mosaic
{
    /// <summary>
    /// Class to wrap the installutil.exe functionality to ease the Mosaic windows service installation.
    /// </summary>
    internal sealed class InstallUtil
    {
        #region Constants

        /// <summary>
        /// Command line of the windows firewall configuration utility.
        /// </summary>
        private const string CmdConfigureFirewall = "netsh.exe";
        
        /// <summary>
        /// Command line template for adding a new firewall rule on windows xp.
        /// </summary>
        private const string CmdLineAddFirewallRuleXP = "firewall add allowedprogram program={0} name=Mosaic mode=ENABLE scope=ALL";

        /// <summary>
        /// Command line template for removing a firewall rule on windows xp.
        /// </summary>
        private const string CmdLineDeleteFirewallRuleXP = "firewall delete allowedprogram program={0}";

        /// <summary>
        /// Command line template for adding a new inbound firewall rule on windows 7 or newer.
        /// </summary>
        private const string CmdLineAddFirewallRuleInbound7 = "advfirewall firewall add rule name=\"Mosaic\" dir=in program={0} action=allow";

        /// <summary>
        /// Command line template for adding a new outbound firewall rule on windows 7 or newer.
        /// </summary>
        private const string CmdLineAddFirewallRuleOutbound7 = "advfirewall firewall add rule name=\"Mosaic\" dir=out program={0} action=allow";

        /// <summary>
        /// Command line template for removing an inbound firewall rule on windows 7 or newer.
        /// </summary>
        private const string CmdLineDeleteFirewallRuleInbound7 = "advfirewall firewall delete rule name=\"Mosaic\" dir=in";

        /// <summary>
        /// Command line template for removing an outbound firewall rule on windows 7 or newer.
        /// </summary>
        private const string CmdLineDeleteFirewallRuleOutbound7 = "advfirewall firewall delete rule name=\"Mosaic\" dir=out";

        /// <summary>
        /// Command to enable WCF self hosting for a specific port and a specific user.
        /// </summary>
        private const string CmdLineAddWcfFirewallRule = "http add urlacl url=http://+:{0}/ user=\"{1}\"";

        /// <summary>
        /// Command to disable WCF self hosting for a specific port.
        /// </summary>
        private const string CmdLineDeleteWcfFirewallRule = "http delete urlacl url=http://+:{0}/";

        /// <summary>
        /// The well known SID of the network service account.
        /// </summary>
        private const string NetworkServiceSid = "S-1-5-20";

        #endregion

        /// <summary>
        /// Installs the Mosaic windows service by executing installutil and configures the windows firewall  
        /// to allow Mosaic to run appropriately.
        /// </summary>
        /// <returns><c>0</c> if successful;<c>-1</c> otherwise.</returns>
        public static int InstallService()
        {
            string mosaicAssembly = string.Format("\"{0}\"", Assembly.GetExecutingAssembly().Location);

            if (RunInstallUtil(mosaicAssembly))
            {
                Console.WriteLine("Mosaic windows service successfully installed -> updating firewall rules.");

                if (Environment.OSVersion.Version.Major > 5)
                {
                    RunNetSh(string.Format(CmdLineAddFirewallRuleInbound7, mosaicAssembly));
                    RunNetSh(string.Format(CmdLineAddFirewallRuleOutbound7, mosaicAssembly));
                }
                else
                {
                    RunNetSh(string.Format(CmdLineAddFirewallRuleXP, mosaicAssembly));
                }

                return 0;
            }
            else
            {
                Console.WriteLine("Installing Mosaic windows service failed!");
            }

            return -1;
        }

        /// <summary>
        /// Uninstalls the Mosaic windows service by executing installutil and removes any Mosaic related 
        /// windows firewall configuration entries.
        /// </summary>
        /// <returns><c>0</c> if successful;<c>-1</c> otherwise.</returns>
        public static int UninstallService()
        {
            string mosaicAssembly = string.Format("\"{0}\"", Assembly.GetExecutingAssembly().Location);
            string commandLine = string.Format("/u {0}", mosaicAssembly);

            if (RunInstallUtil(commandLine))
            {
                Console.WriteLine("Mosaic windows service successfully uninstalled -> updating firewall rules.");

                if (Environment.OSVersion.Version.Major > 5)
                {
                    RunNetSh(CmdLineDeleteFirewallRuleInbound7);
                    RunNetSh(CmdLineDeleteFirewallRuleOutbound7);
                }
                else
                {
                    RunNetSh(string.Format(CmdLineDeleteFirewallRuleXP, mosaicAssembly));
                }

                return 0;
            }
            else
            {
                Console.WriteLine("Uninstalling Mosaic windows service failed!");
            }

            return -1;
        }

        /// <summary>
        /// Adds a WCF firewall rule for the specified port.
        /// </summary>
        /// <param name="port">The port of the WCF service.</param>
        public static void AddWcfFirewallRule(ushort port)
        {
            if (System.Environment.OSVersion.Version.Major <= 5)
            {
                return;
            }

            RunNetSh(string.Format(CmdLineDeleteWcfFirewallRule, port));
            RunNetSh(string.Format(CmdLineAddWcfFirewallRule, port, GetNetworkServiceName()));            
        }

        /// <summary>
        /// Gets the localized name of the network service account.
        /// </summary>
        /// <value>
        /// The name of the network service account.
        /// </value>
        public  static string GetNetworkServiceName()
        {
            IntPtr pSid = IntPtr.Zero;

            try
            {
                if (Advapi32.ConvertStringSidToSid(NetworkServiceSid, out pSid) == false)
                {
                    return string.Empty;
                }

                uint cchName = 1024;
                uint cchDomainName = 1024;
                StringBuilder lpName = new StringBuilder((int)cchName);
                StringBuilder lpDomainName = new StringBuilder((int)cchDomainName);
                int euse = 0;

                if (Advapi32.LookupAccountSid(null, pSid, lpName, ref cchName, lpDomainName, ref cchDomainName, out euse) == false)
                {
                    return string.Empty;
                }

                return lpName.ToString();
            }
            finally
            {
                if (pSid != IntPtr.Zero)
                {
                    Kernel32.LocalFree(pSid);
                }
            }
        }
        
        /// <summary>
        /// Runs the installutil.exe command with the specified command line parameters.
        /// </summary>
        /// <param name="commandLine">The command line arguments to pass to installutil.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        private static bool RunInstallUtil(string commandLine)
        {
            Process proc = null;
            string installUtilCommand = string.Format("\"{0}installutil.exe\"", 
                                                      RuntimeEnvironment.GetRuntimeDirectory());

            try
            {
                Console.WriteLine("");
                Console.WriteLine("Installutil: {0}", installUtilCommand);
                Console.WriteLine("Arguments: {0}", commandLine);
                Console.WriteLine("");
                Console.WriteLine("------------------------------------");

                proc = new Process();
                proc.StartInfo.FileName = installUtilCommand;
                proc.StartInfo.Arguments = commandLine;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.UseShellExecute = false;

                proc.Start();
                proc.WaitForExit();

                Console.WriteLine("------------------------------------");
                Console.WriteLine("");

                return (proc.ExitCode == 0);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("InstallUtil failed with error {0}.", ex.Message);
            }
            finally
            {
                if (proc != null)
                    proc.Close();
            }

            return false;
        }

        /// <summary>
        /// Runs the netsh command with the specified command line parameters.
        /// </summary>
        /// <param name="commandLine">The command line arguments to pass to netsh.</param>
        private static void RunNetSh(string commandLine)
        {
            Process proc = null;

            string netshFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), CmdConfigureFirewall);

            try
            {
                Console.WriteLine("Configure firewall with '{0} {1}' ...", netshFileName, commandLine);

                proc = new Process();
                proc.StartInfo.FileName = netshFileName;
                proc.StartInfo.Arguments = commandLine;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.ErrorDialog = false;

                proc.Start();
                proc.WaitForExit();

                Console.WriteLine("------------------------------------");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Netsh failed with error {0}.", ex.Message);
            }
            finally
            {
                if (proc != null)
                    proc.Close();
            }
        }
    }
}
