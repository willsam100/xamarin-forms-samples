namespace Notes

open System
open System.IO
open Xamarin.Forms
open Notes.Models
open Xamarin.Forms.Xaml

type IFolderPath = 
    abstract member FolderPath: string

type NoteEntryPage(folderPath: IFolderPath) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<NoteEntryPage>

    member this.OnSaveButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            if String.IsNullOrWhiteSpace(note.Filename) then
                let mutable filename = Path.Combine(folderPath.FolderPath, sprintf "%O.notes.txt" (Path.GetRandomFileName()))
                File.WriteAllText(filename, note.Text)
            else File.WriteAllText(note.Filename, note.Text)
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate

    member this.OnDeleteButtonClicked(sender: obj, e: EventArgs) =
        async {
            let mutable note = (this.BindingContext :?> Note)
            if File.Exists(note.Filename) then File.Delete(note.Filename)
            do! this.Navigation.PopAsync() |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate