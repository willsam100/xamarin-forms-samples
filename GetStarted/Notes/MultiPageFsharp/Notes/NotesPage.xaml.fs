namespace Notes

open System
open System.Collections.Generic
open System.IO
open System.Linq
open Xamarin.Forms
open Notes.Models
open Xamarin.Forms.Xaml

type NotesPage(folderPath: IFolderPath) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<NotesPage>
    let listView = base.FindByName<ListView> "listView"

    override this.OnAppearing() =
        base.OnAppearing()
        let mutable notes = new List<Note>()
        let mutable files = Directory.EnumerateFiles(folderPath.FolderPath, "*.notes.txt")
        for filename in files do
            notes.Add
                (new Note(Filename = filename, Text = File.ReadAllText(filename), Date = File.GetCreationTime(filename)))
        listView.ItemsSource <- notes.OrderBy(fun d -> d.Date).ToList()

    member this.OnNoteAddedClicked(sender: obj, e: EventArgs) =
        async { do! this.Navigation.PushAsync(new NoteEntryPage(folderPath, BindingContext = (new Note()))) |> Async.AwaitTask |> Async.Ignore }
        |> Async.StartImmediate
        
    member this.OnListViewItemSelected(sender: obj, e: SelectedItemChangedEventArgs) =
        async {
            if e.SelectedItem <> null then
                do! this.Navigation.PushAsync(new NoteEntryPage(folderPath, BindingContext = (e.SelectedItem :?> Note))) |> Async.AwaitTask |> Async.Ignore 
        }
        |> Async.StartImmediate