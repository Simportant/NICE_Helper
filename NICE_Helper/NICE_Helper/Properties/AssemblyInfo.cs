using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NICE_Helper")]
[assembly: AssemblyDescription("Created to work with NICE RTI installations")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("SVL Business Solutions")]
[assembly: AssemblyProduct("NICE Log Viewer")]
[assembly: AssemblyCopyright("Copyright © 2019")]
[assembly: AssemblyTrademark("SMG")]
[assembly: AssemblyCulture("")]

// Set up Log4Net.
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("17cda18e-18dd-4c0a-a0ac-8a4d164db91c")]

[assembly: AssemblyVersion("5.0.0.0")]
[assembly: AssemblyFileVersion("5.0.0.0")]
