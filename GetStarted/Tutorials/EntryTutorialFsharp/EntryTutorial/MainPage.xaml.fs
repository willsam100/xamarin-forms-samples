namespace EntryTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>

    member this.OnEntryTextChanged(sender: obj, e: TextChangedEventArgs) =
        let mutable oldText = e.OldTextValue
        let mutable newText = e.NewTextValue
        ()

    member this.OnEntryCompleted(sender: obj, e: EventArgs) =
        let mutable text = (sender :?> Entry).Text
        ()