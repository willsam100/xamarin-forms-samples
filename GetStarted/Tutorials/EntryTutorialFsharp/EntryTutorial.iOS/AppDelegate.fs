namespace EntryTutorial.iOS

open System
open System.Collections.Generic
open System.Linq
open Foundation
open UIKit

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit global.Xamarin.Forms.Platform.iOS.FormsApplicationDelegate()
    override this.FinishedLaunching(app: UIApplication, options: NSDictionary): bool =
        global.Xamarin.Forms.Forms.Init()
        base.LoadApplication(new EntryTutorial.App())
        base.FinishedLaunching(app, options)