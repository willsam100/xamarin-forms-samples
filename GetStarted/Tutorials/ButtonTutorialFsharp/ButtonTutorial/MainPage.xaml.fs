namespace ButtonTutorial

open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    member this.OnButtonClicked(sender: obj, e: EventArgs) = (sender :?> Button).Text <- "Click me again!"