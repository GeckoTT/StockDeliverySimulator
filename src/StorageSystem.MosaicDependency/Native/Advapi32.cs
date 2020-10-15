using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CareFusion.Mosaic.Native
{
    /// <summary>
    /// Class which contains all function import definitions of the advapi32.dll. 
    /// </summary>
    public static class Advapi32
    {
        #region Constants

        /// <summary>
        /// Includes STANDARD_RIGHTS_REQUIRED, in addition to get all access rights in the service table.
        /// </summary>
        public const uint SC_MANAGER_ALL_ACCESS = 0xF003F;

        /// <summary>
        /// A service started by the service control manager when a process calls the StartService function.
        /// </summary>
        public const uint SERVICE_DEMAND_START = 0x00000003;

        /// <summary>
        /// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS structure.
        /// </summary>
        public const uint SERVICE_CONFIG_FAILURE_ACTIONS = 2;

        /// <summary>
        /// Required access right to query an access token.
        /// </summary>
        public const uint TOKEN_QUERY = 0x0008;

        #endregion

        #region Enums

        /// <summary>
        /// The SC_ACTION_TYPE enumeration specifies action levels for the Type member of the SC_ACTION structure.
        /// </summary>
        public enum SC_ACTION_TYPE : int 
        {
            SC_ACTION_NONE=0,
            SC_ACTION_RESTART=1,
            SC_ACTION_REBOOT=2,
            SC_ACTION_RUN_COMMAND=3
        }

        /// <summary>
        /// The TOKEN_INFORMATION_CLASS enumeration contains values that specify 
        /// the type of information being assigned to or retrieved from an access token.
        /// </summary>
        public enum TOKEN_INFORMATION_CLASS : int
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            TokenIsAppContainer,
            TokenCapabilities,
            TokenAppContainerSid,
            TokenAppContainerNumber,
            TokenUserClaimAttributes,
            TokenDeviceClaimAttributes,
            TokenRestrictedUserClaimAttributes,
            TokenRestrictedDeviceClaimAttributes,
            TokenDeviceGroups,
            TokenRestrictedDeviceGroups,
            TokenSecurityAttributes,
            TokenIsRestricted,
            MaxTokenInfoClass
        }

        #endregion

        #region Types

        /// <summary>
        /// Contains configuration information for an installed service.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct QUERY_SERVICE_CONFIG 
        {
            /// <summary>
            /// The type of service.
            /// </summary>
            public uint dwServiceType;

            /// <summary>
            /// When to start the service.
            /// </summary>
            public uint dwStartType;
            
            /// <summary>
            /// The severity of the error, and action taken, if this service fails to start.
            /// </summary>
            public uint dwErrorControl;

            /// <summary>
            /// The fully qualified path to the service binary file. 
            /// </summary>
            public string lpBinaryPathName;

            /// <summary>
            /// The name of the load ordering group to which this service belongs. 
            /// </summary>
            public string lpLoadOrderGroup;

            /// <summary>
            /// A unique tag value for this service in the group specified by the lpLoadOrderGroup parameter. 
            /// </summary>
            public uint dwTagId;

            /// <summary>
            /// A pointer to an array of null-separated names of services or load ordering groups that must start before this service.
            /// </summary>
            public string lpDependencies;

            /// <summary>
            /// If the service type is SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, this member is the name of the 
            /// account that the service process will be logged on as when it runs.
            /// </summary>
            public string lpServiceStartName;

            /// <summary>
            /// The display name to be used by service control programs to identify the service.
            /// </summary>
            public string lpDisplayName;
        }

        /// <summary>
        /// Represents the action the service controller should take on each failure of a service.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SERVICE_FAILURE_ACTIONS 
        {
            /// <summary>
            /// The time after which to reset the failure count to zero if there are no failures, in seconds.
            /// </summary>
            public uint dwResetPeriod;

            /// <summary>
            /// The message to be broadcast to server users before rebooting in response to the SC_ACTION_REBOOT service controller action.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpRebootMsg;

            /// <summary>
            /// The command line of the process for the CreateProcess function to execute in response to the SC_ACTION_RUN_COMMAND service controller action. 
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpCommand;

            /// <summary>
            /// The number of elements in the lpsaActions array.
            /// </summary>
            public uint cActions;

            /// <summary>
            /// A pointer to an array of SC_ACTION structures.
            /// </summary>
            public IntPtr lpsaActions;
        }

        /// <summary>
        /// Represents an action that the service control manager can perform.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SC_ACTION
        {
            /// <summary>
            /// The action to be performed. This member can be one of the following values from the SC_ACTION_TYPE enumeration type.
            /// </summary>
            public SC_ACTION_TYPE Type;

            /// <summary>
            /// The time to wait before performing the specified action, in milliseconds.
            /// </summary>
            public uint Delay;
        } 

        #endregion

        #region Function Imports

        /// <summary>
        /// Establishes a connection to the service control manager on the specified computer and opens the specified service control manager database.
        /// </summary>
        /// <param name="lpMachineName">
        /// The name of the target computer. If the pointer is NULL or points to an empty string, 
        /// the function connects to the service control manager on the local computer.
        /// </param>
        /// <param name="lpDatabaseName">
        /// The name of the service control manager database. This parameter should be set to SERVICES_ACTIVE_DATABASE. 
        /// If it is NULL, the SERVICES_ACTIVE_DATABASE database is opened by default.
        /// </param>
        /// <param name="dwDesiredAccess">The access to the service control manager.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified service control manager database.
        /// If the function fails, the return value is NULL. 
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr OpenSCManager(string lpMachineName, string lpDatabaseName, uint dwDesiredAccess);

        /// <summary>
        /// Opens an existing service.
        /// </summary>
        /// <param name="hSCManager">A handle to the service control manager database. </param>
        /// <param name="lpServiceName">The name of the service to be opened.</param>
        /// <param name="dwDesiredAccess">The access to the service.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the service.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

        /// <summary>
        /// Retrieves the configuration parameters of the specified service. 
        /// </summary>
        /// <param name="hService">A handle to the service.</param>
        /// <param name="lpServiceConfig">A pointer to a buffer that receives the service configuration information.</param>
        /// <param name="cbBufSize">The size of the buffer pointed to by the lpServiceConfig parameter, in bytes.</param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to store all the configuration information.
        /// </param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool QueryServiceConfig(IntPtr hService, IntPtr lpServiceConfig, uint cbBufSize, out uint pcbBytesNeeded);

        /// <summary>
        /// Changes the configuration parameters of a service.
        /// </summary>
        /// <param name="hService">A handle to the service.</param>
        /// <param name="dwServiceType">The type of service.</param>
        /// <param name="dwStartType">The service start options.</param>
        /// <param name="dwErrorControl">The severity of the error, and action taken, if this service fails to start.</param>
        /// <param name="lpBinaryPathName">The fully qualified path to the service binary file. </param>
        /// <param name="lpLoadOrderGroup">The name of the load ordering group of which this service is a member. S</param>
        /// <param name="lpdwTagId">
        /// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. 
        /// Specify NULL if you are not changing the existing tag. 
        /// </param>
        /// <param name="lpDependencies">
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the 
        /// system must start before this service can be started. 
        /// </param>
        /// <param name="lpServiceStartName">
        /// The name of the account under which the service should run.
        /// Specify NULL if you are not changing the existing account name.
        /// </param>
        /// <param name="lpPassword">
        /// The password to the account name specified by the lpServiceStartName parameter. 
        /// Specify NULL if you are not changing the existing password.
        /// </param>
        /// <param name="lpDisplayName">
        /// The display name to be used by applications to identify the service for its users. 
        /// Specify NULL if you are not changing the existing display name;
        /// </param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool ChangeServiceConfig(IntPtr hService, uint dwServiceType, uint dwStartType, uint dwErrorControl,
                                                      string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId,
                                                      string lpDependencies, string lpServiceStartName, string lpPassword,
                                                      string lpDisplayName);

        /// <summary>
        /// Changes the optional configuration parameters of a service.
        /// </summary>
        /// <param name="hService">A handle to the service.</param>
        /// <param name="dwInfoLevel">The configuration information to be changed.</param>
        /// <param name="lpInfo">A pointer to the new value to be set for the configuration information.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool ChangeServiceConfig2(IntPtr hService, uint dwInfoLevel, IntPtr lpInfo);

        /// <summary>
        /// Closes a handle to a service control manager or service object.
        /// </summary>
        /// <param name="hSCObject">A handle to the service control manager object or the service object to close.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CloseServiceHandle(IntPtr hSCObject);


        /// <summary>
        /// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID.
        /// </summary>
        /// <param name="StringSid">
        /// A pointer to a null-terminated string containing the string-format SID to convert. 
        /// The SID string can use either the standard S-R-I-S-S… format for SID strings, or the SID string constant format, 
        /// such as "BA" for built-in administrators. For more information about SID string notation, see SID Components.
        /// </param>
        /// <param name="pSid">A pointer to a variable that receives a pointer to the converted SID. To free the returned buffer, call the LocalFree function.</param>
        /// <returns>If the function succeeds, the return value is false.</returns>
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool ConvertStringSidToSid(string StringSid, out IntPtr pSid);

        /// <summary>
        /// The LookupAccountSid function accepts a security identifier (SID) as input. 
        /// It retrieves the name of the account for this SID and the name of the first domain on which this SID is found.
        /// </summary>
        /// <param name="lpSystemName">
        /// A pointer to a null-terminated character string that specifies the target computer. 
        /// This string can be the name of a remote computer. If this parameter is NULL, the account name translation begins on the local system. 
        /// If the name cannot be resolved on the local system, this function will try to resolve the name using domain controllers trusted by the local system. 
        /// Generally, specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
        /// </param>
        /// <param name="pSid">A pointer to the SID to look up.</param>
        /// <param name="lpName">A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.</param>
        /// <param name="cchName">
        /// On input, specifies the size, in TCHARs, of the lpName buffer. 
        /// If the function fails because the buffer is too small or if cchName is zero, cchName receives the required buffer size, including the terminating null character.
        /// </param>
        /// <param name="lpReferencedDomainName">
        /// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
        /// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain for which the server is a domain controller.
        /// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the computer as of the last start of the system 
        /// (backslashes are excluded). If the name of the computer changes, the old name continues to be returned as the domain name until the system is restarted.
        /// Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.
        /// </param>
        /// <param name="cchReferencedDomainName">
        /// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. 
        /// If the function fails because the buffer is too small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating null character.
        /// </param>
        /// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
        /// <returns>If the function succeeds, the function returns false.</returns>
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool LookupAccountSid(string lpSystemName, 
                                                   IntPtr pSid, 
                                                   StringBuilder lpName, 
                                                   ref uint cchName, 
                                                   StringBuilder lpReferencedDomainName, 
                                                   ref uint cchReferencedDomainName, 
                                                   out int peUse);

        /// <summary>
        /// The OpenProcessToken function opens the access token associated with a process.
        /// </summary>
        /// <param name="hProcessHandle">
        /// A handle to the process whose access token is opened. 
        /// The process must have the PROCESS_QUERY_INFORMATION access permission.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Specifies an access mask that specifies the requested types of access to the access token. 
        /// These requested access types are compared with the discretionary access control list (DACL) 
        /// of the token to determine which accesses are granted or denied. 
        /// </param>
        /// <param name="hTokenHandle">
        /// A pointer to a handle that identifies the newly opened access token when the function returns.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful; <c>false</c> otherwise.
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool OpenProcessToken(IntPtr hProcessHandle,
                                                   uint dwDesiredAccess,
                                                   out IntPtr hTokenHandle);

        /// <summary>
        /// The GetTokenInformation function retrieves a specified type of information about an access token. 
        /// The calling process must have appropriate access rights to obtain the information.
        /// </summary>
        /// <param name="hTokenHandle">
        /// A handle to an access token from which information is retrieved. If TokenInformationClass specifies 
        /// TokenSource, the handle must have TOKEN_QUERY_SOURCE access. For all other TokenInformationClass values, 
        /// the handle must have TOKEN_QUERY access.
        /// </param>
        /// <param name="tokenInformationClass">
        /// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information 
        /// the function retrieves. Any callers who check the TokenIsAppContainer and have it return 0 should also 
        /// verify that the caller token is not an identify level impersonation token. If the current token is not 
        /// an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="pTokenInformation">
        /// A pointer to a buffer the function fills with the requested information. The structure put into this 
        /// buffer depends upon the type of information specified by the TokenInformationClass parameter.
        /// </param>
        /// <param name="dwTokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the TokenInformation parameter. 
        /// If TokenInformation is NULL, this parameter must be zero.
        /// </param>
        /// <param name="dwReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the 
        /// TokenInformation parameter. If this value is larger than the value specified in the TokenInformationLength 
        /// parameter, the function fails and stores no data in the buffer.
        /// If the value of the TokenInformationClass parameter is TokenDefaultDacl and the token has no default DACL, 
        /// the function sets the variable pointed to by ReturnLength to sizeof(TOKEN_DEFAULT_DACL) and sets the 
        /// DefaultDacl member of the TOKEN_DEFAULT_DACL structure to NULL.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful; <c>false</c> otherwise.
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool GetTokenInformation(IntPtr hTokenHandle,
                                                      TOKEN_INFORMATION_CLASS tokenInformationClass,
                                                      out uint pTokenInformation,
                                                      uint dwTokenInformationLength,
                                                      out uint dwReturnLength);

        /// <summary>
        /// The GetTokenInformation function retrieves a specified type of information about an access token. 
        /// The calling process must have appropriate access rights to obtain the information.
        /// </summary>
        /// <param name="hTokenHandle">
        /// A handle to an access token from which information is retrieved. If TokenInformationClass specifies 
        /// TokenSource, the handle must have TOKEN_QUERY_SOURCE access. For all other TokenInformationClass values, 
        /// the handle must have TOKEN_QUERY access.
        /// </param>
        /// <param name="tokenInformationClass">
        /// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information 
        /// the function retrieves. Any callers who check the TokenIsAppContainer and have it return 0 should also 
        /// verify that the caller token is not an identify level impersonation token. If the current token is not 
        /// an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="pTokenInformation">
        /// A pointer to a buffer the function fills with the requested information. The structure put into this 
        /// buffer depends upon the type of information specified by the TokenInformationClass parameter.
        /// </param>
        /// <param name="dwTokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the TokenInformation parameter. 
        /// If TokenInformation is NULL, this parameter must be zero.
        /// </param>
        /// <param name="dwReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the 
        /// TokenInformation parameter. If this value is larger than the value specified in the TokenInformationLength 
        /// parameter, the function fails and stores no data in the buffer.
        /// If the value of the TokenInformationClass parameter is TokenDefaultDacl and the token has no default DACL, 
        /// the function sets the variable pointed to by ReturnLength to sizeof(TOKEN_DEFAULT_DACL) and sets the 
        /// DefaultDacl member of the TOKEN_DEFAULT_DACL structure to NULL.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful; <c>false</c> otherwise.
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool GetTokenInformation(IntPtr hTokenHandle,
                                                      TOKEN_INFORMATION_CLASS tokenInformationClass,
                                                      IntPtr pTokenInformation,
                                                      uint dwTokenInformationLength,
                                                      out uint dwReturnLength);

        #endregion
    }
}

