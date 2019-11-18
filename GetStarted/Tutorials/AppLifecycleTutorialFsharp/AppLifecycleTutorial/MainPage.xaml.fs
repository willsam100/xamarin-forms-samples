namespace AppLifecycleTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

// Use an interface since F# does not allow circular dependencies
type IApp = 
    abstract DisplayText: string with get,set

type MainPage(app: IApp) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let entry = base.FindByName<Entry>("entry")

    override this.OnAppearing() =
        base.OnAppearing()
        entry.Text <- app.DisplayText

    member this.OnEntryCompleted(sender: obj, e: EventArgs) =   
        app.DisplayText <- entry.Text