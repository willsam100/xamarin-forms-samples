namespace EditorTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>

    member this.OnEditorTextChanged(sender: obj, e: TextChangedEventArgs) =
        let mutable oldText = e.OldTextValue
        let mutable newText = e.NewTextValue
        ()

    member this.OnEditorCompleted(sender: obj, e: EventArgs) =
        let mutable text = (sender :?> Editor).Text
        ()