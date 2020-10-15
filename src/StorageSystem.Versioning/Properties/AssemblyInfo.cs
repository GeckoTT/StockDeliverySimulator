using System.Reflection;
using System.Runtime.InteropServices;

using StorageSystem.Versioning;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyConfiguration( VersionInfoProvider.Configuration )]
[assembly: AssemblyCompany( VersionInfoProvider.Company )]
[assembly: AssemblyProduct( VersionInfoProvider.Product )]
[assembly: AssemblyCopyright( VersionInfoProvider.Copyright )]
[assembly: AssemblyTitle( "StorageSystem library version information." )]
[assembly: AssemblyDescription( "StorageSystem library version information." )]
[assembly: AssemblyTrademark( VersionInfoProvider.Trademark )]
[assembly: AssemblyCulture( VersionInfoProvider.Culture )]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid( "F2E22193-9A61-410E-827B-4A98A8F8E5F5" )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion( VersionInfoProvider.AssemblyVersion )]
[assembly: AssemblyFileVersion( VersionInfoProvider.FileVersion )]
[assembly: AssemblyInformationalVersion( VersionInfoProvider.ProductVersion )]
