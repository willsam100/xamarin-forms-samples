namespace Notes

open System
open System.IO
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml typeof<MainPage>
    let _editor = base.FindByName<Editor> "_editor"
    
    let mutable _fileName =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt")

    do
        if File.Exists(_fileName) then _editor.Text <- File.ReadAllText(_fileName)

    member this.OnSaveButtonClicked(sender: obj, e: EventArgs) = File.WriteAllText(_fileName, _editor.Text)
    member this.OnDeleteButtonClicked(sender: obj, e: EventArgs) =
        if File.Exists(_fileName) then File.Delete(_fileName)
        _editor.Text <- String.Empty