namespace AwesomeApp.Droid
open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Android.App

type Resources = AwesomeApp.Droid.Resource
[<assembly: Android.Runtime.ResourceDesigner("AwesomeApp.Droid.Resources", IsApplication=true)>]

[<assembly:AssemblyTitle("AwesomeApp.Android")>]
[<assembly:AssemblyDescription("")>]
[<assembly:AssemblyConfiguration("")>]
[<assembly:AssemblyCompany("")>]
[<assembly:AssemblyProduct("AwesomeApp.Android")>]
[<assembly:AssemblyCopyright("Copyright ©  2014")>]
[<assembly:AssemblyTrademark("")>]
[<assembly:AssemblyCulture("")>]
[<assembly:ComVisible(false)>]
[<assembly:AssemblyVersion("1.0.0.0")>]
[<assembly:AssemblyFileVersion("1.0.0.0")>]
[<assembly:UsesPermission(Android.Manifest.Permission.Internet)>]
[<assembly:UsesPermission(Android.Manifest.Permission.WriteExternalStorage)>]
do ()
