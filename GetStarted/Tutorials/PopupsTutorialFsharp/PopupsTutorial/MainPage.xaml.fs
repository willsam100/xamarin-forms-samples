namespace PopupsTutorial

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    
    
    member this.OnDisplayAlertButtonClicked(sender: obj, e: EventArgs) =
        async { do! this.DisplayAlert("Alert", "This is an alert.", "OK") |> Async.AwaitTask } |> Async.StartImmediate
        
    member this.OnDisplayAlertQuestionButtonClicked(sender: obj, e: EventArgs) =
        async { let! response = this.DisplayAlert("Save?", "Would you like to save your data?", "Yes", "No")
                                |> Async.AwaitTask
                return Console.WriteLine("Save data: " + (response.ToString())) } |> Async.StartImmediate
                
    member this.OnDisplayActionSheetButtonClicked(sender: obj, e: EventArgs) =
        async { let! action = this.DisplayActionSheet("Send to?", "Cancel", null, "Email", "Twitter", "Facebook")
                              |> Async.AwaitTask
                return Console.WriteLine("Action: " + (action.ToString())) } |> Async.StartImmediate