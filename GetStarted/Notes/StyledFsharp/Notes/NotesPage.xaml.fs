namespace Notes

open System
open Xamarin.Forms
open Notes.Models
open Xamarin.Forms.Xaml
open Notes.Data

type NotesPage(noteDatabse: INoteDatabase) =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<NotesPage>
    let listView = base.FindByName<ListView> "listView"

    override this.OnAppearing() =
        base.OnAppearing()
        async { let! notesAsync = noteDatabse.GetNotesAsync() |> Async.AwaitTask
                listView.ItemsSource <- notesAsync } |> Async.StartImmediate

    member this.OnNoteAddedClicked(sender: obj, e: EventArgs) =
        async { do! this.Navigation.PushAsync(new NoteEntryPage(noteDatabse, BindingContext = (new Note()))) |> Async.AwaitTask |> Async.Ignore}
        |> Async.StartImmediate
        
    member this.OnListViewItemSelected(sender: obj, e: SelectedItemChangedEventArgs) =
        async {
            if e.SelectedItem <> null then
                do! this.Navigation.PushAsync(new NoteEntryPage(noteDatabse, BindingContext = (e.SelectedItem :?> Note))) |> Async.AwaitTask |> Async.Ignore
        }
        |> Async.StartImmediate