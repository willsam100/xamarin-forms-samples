namespace Notes

open System
open Xamarin.Forms
open Notes.Models
open Xamarin.Forms.Xaml
open Notes.Data

type NoteEntryPage(noteDatatbase: INoteDatabase) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<NoteEntryPage>

    member this.OnSaveButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            note.Date <- DateTime.UtcNow
            do! noteDatatbase.SaveNoteAsync(note) |> Async.AwaitTask |> Async.Ignore
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate

    member this.OnDeleteButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            do! noteDatatbase.DeleteNoteAsync(note) |> Async.AwaitTask |> Async.Ignore
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate