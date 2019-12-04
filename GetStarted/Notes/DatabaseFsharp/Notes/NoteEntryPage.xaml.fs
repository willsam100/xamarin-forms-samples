namespace Notes

open System
open Xamarin.Forms
open Notes.Models
open Notes.Data
open Xamarin.Forms.Xaml

type NoteEntryPage(database: INoteDatabase) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<NoteEntryPage>

    member this.OnSaveButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            note.Date <- DateTime.UtcNow
            do! database.SaveNoteAsync(note) |> Async.AwaitTask |> Async.Ignore
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate

    member this.OnDeleteButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            do! database.DeleteNoteAsync(note) |> Async.AwaitTask |> Async.Ignore
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate