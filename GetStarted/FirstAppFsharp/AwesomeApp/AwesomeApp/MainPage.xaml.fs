namespace AwesomeApp

open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Threading.Tasks
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration.iOSSpecific
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let mutable count = 0
    do base.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true) |> ignore
    member private this.Button_Clicked(sender: obj, e: EventArgs) =
        count <- count + 1
        (sender :?> Button).Text <- sprintf "You clicked %O times." (count)